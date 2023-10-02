using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Persistence.Repositories.UnitOfWork;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.MarkService.Request;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.MarkService.Response;

namespace RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.MarkService
{
    public class MarkServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public MarkServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateMark(CreateMarkRequestModel request)
        {
            var mark = await _unitOfWork.MarkRepository.GetSingleAsync(x => x.MarkName == request.MarkName.ToUpper() && x.IsDeleted == false);
            if (mark != null)
            {
                throw new Exception("მსგავსი მარკა უკვე არსებობს");
            }
            var entity = Mark.CreateMark(request.MarkName);
            await _unitOfWork.MarkRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<GetMarksResultModel>> GetMarks(bool onlyActive)
        {
            var result = new List<GetMarksResultModel>();
            var marks = await _unitOfWork.MarkRepository.GetAllAsync();
            if (onlyActive)
            {
                marks = marks.Where(x => !x.IsDeleted).ToList();
            }
            foreach (var mark in marks)
            {
                result.Add(new GetMarksResultModel { Id = mark.Id, MarkName = mark.MarkName, IsActive = !mark.IsDeleted });
            }

            return result;
        }

        public async Task<List<GetMarkModelsResult>> GetMarkModelsWithFilter(GetMarkModelsRequest request)
        {
            var result = new List<GetMarkModelsResult>();
            var models = (await _unitOfWork.ModelRepository.GetAllAsync()).Where(x => x.IsDeleted == false);
            if (request.Id.HasValue)
            {
                models = models.Where(x => x.MarkId == request.Id).ToList();
            }
            if (!string.IsNullOrEmpty(request.MarkName))
            {
                models = models.Where(x => x.Mark.MarkName.ToUpper() == request.MarkName.ToUpper()).ToList();
            }

            foreach (var model in models)
            {
                result.Add(new GetMarkModelsResult
                {
                    MarkId = model.MarkId,
                    MarkName = model.Mark.MarkName,
                    ModelId = model.Id,
                    ModelName = model.ModelName
                });
            }

            return result;
        }

        public async Task DeleteMark(int id)
        {
            var entity = await _unitOfWork.MarkRepository.GetSingleAsync(x => x.Id == id && x.IsDeleted == false) ?? throw new Exception("ჩანაწერი არ არსებობს");
            entity.Delete();
            foreach (var model in entity.Models)
            {
                model.Delete();
                _unitOfWork.ModelRepository.Update(model);
            }

            _unitOfWork.MarkRepository.Update(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task ReactiveMark(int id)
        {
            var mark = await _unitOfWork.MarkRepository.GetSingleAsync(x => x.Id == id) ?? throw new Exception("ჩანაწერი არ არსებობს");
            mark.ReActive();
            foreach (var model in mark.Models)
            {
                model.ReActive();
                _unitOfWork.ModelRepository.Update(model);
            }
            _unitOfWork.MarkRepository.Update(mark);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

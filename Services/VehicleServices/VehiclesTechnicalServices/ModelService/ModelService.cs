using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Persistence.Repositories.UnitOfWork;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService.Models.Request;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService.Models.Response;

namespace RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService
{
    public class ModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateModel(CreateModelRequestModel request)
        {
            var mark = await _unitOfWork.MarkRepository.GetSingleAsync(x => x.Id == request.MarkId && x.IsDeleted == false) ?? throw new Exception("მარკა არ არსებობს");
            var modelEntity = Model.Create(request.ModelName);
            modelEntity.AssignMark(mark);
            await _unitOfWork.ModelRepository.AddAsync(modelEntity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<GetVehicleModelResult> GetModel(int modelId)
        {
            var model = await _unitOfWork.ModelRepository.GetSingleAsync(x => x.Id == modelId && x.IsDeleted == false) ?? throw new Exception("ჩანაწერი არ მოიძებნა");

            return new GetVehicleModelResult { Id = modelId, MarkName = model.Mark.MarkName, ModelName = model.ModelName };
        }

        public async Task<List<GetVehicleModelResult>> GetModels(bool onlyActive)
        {
            var resultModel = new List<GetVehicleModelResult>();
            var models = await _unitOfWork.ModelRepository.GetAllAsync();
            if (onlyActive)
            {
                models = models.Where(x => !x.IsDeleted).ToList();
            }
            foreach (var item in models)
            {
                resultModel.Add(new GetVehicleModelResult { Id = item.Id, MarkName = item.Mark.MarkName, ModelName = item.ModelName, IsActive = !item.IsDeleted });
            }

            return resultModel;
        }

        public async Task DeleteModel(int id)
        {
            var entity = await _unitOfWork.ModelRepository.GetSingleAsync(x => x.Id == id && x.IsDeleted == false) ?? throw new Exception("ჩანაწერი არ არსებობს");
            entity.Delete();
            _unitOfWork.ModelRepository.Update(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task ReactiveModel(int id)
        {
            var entity = await _unitOfWork.ModelRepository.GetSingleAsync(x => x.Id == id) ?? throw new Exception("ჩანაწერი არ მოიძებნა");
            entity.ReActive();
            _unitOfWork.ModelRepository.Update(entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

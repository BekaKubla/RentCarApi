using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Persistence.Repositories.UnitOfWork;
using RentCarApi.Services.VehicleServices.VehicleService.Request;
using RentCarApi.Services.VehicleServices.VehicleService.Response;

namespace RentCarApi.Services.VehicleServices.VehicleService
{
    public class VehiclesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiclesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateVehicle(CreateVehicleModel request)
        {
            var mark = await _unitOfWork.MarkRepository.GetSingleAsync(x => x.Id == request.MarkId) ?? throw new Exception("მარკა არ მოიძებნა");
            var model = await _unitOfWork.ModelRepository.GetSingleAsync(x => x.Id == request.ModelId) ?? throw new Exception("მოდელი არ მოიძებნა");
            var location = await _unitOfWork.VehicleLocationRepository.GetSingleAsync(x => x.Id == request.VehicleLocationId) ?? throw new Exception("მისამართი არ მოიძებნა");

            var entity = Vehicle.CreateVehicle(request.SeatCount,
                                               request.AirCondition,
                                               request.DoorsCount,
                                               request.LuggagesCount,
                                               request.RentalPrice,
                                               request.Transmission,
                                               request.ReleaseYear,
                                               request.EngineVolume);
            entity.AssignMark(mark);
            entity.AssignModel(model);
            entity.AssignLocation(location);

            await _unitOfWork.VehicleRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<CreateVehicleResult>> GetVehicles(bool onlyActive)
        {
            var result = new List<CreateVehicleResult>();

            var vehicles = await _unitOfWork.VehicleRepository.GetAllAsync();
            if (!onlyActive)
            {
                vehicles = vehicles.Where(x => !x.IsDeleted).ToList();
            }
            foreach (var vehicle in vehicles)
            {
                result.Add(new CreateVehicleResult
                {
                    SeatCount = vehicle.SeatCount,
                    AirCondition = vehicle.AirCondition,
                    DoorsCount = vehicle.DoorsCount,
                    EngineVolume = vehicle.EngineVolume,
                    LuggagesCount = vehicle.LuggagesCount,
                    MarkName = vehicle.Mark?.MarkName,
                    ModelName = vehicle.Model?.ModelName,
                    ReleaseYear = vehicle.ReleaseYear,
                    RentalPrice = vehicle.RentalPrice,
                    Transmission = vehicle.Transmission,
                    LocationName = vehicle.VehicleLocation?.Location
                });
            }
            return result;
        }

        public async Task<CreateVehicleResult> GetVehicles(int id)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetSingleAsync(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("მანქანა არ მოიძებნა");
            return new CreateVehicleResult
            {
                SeatCount = vehicle.SeatCount,
                AirCondition = vehicle.AirCondition,
                DoorsCount = vehicle.DoorsCount,
                EngineVolume = vehicle.EngineVolume,
                LuggagesCount = vehicle.LuggagesCount,
                MarkName = vehicle.Mark?.MarkName,
                ModelName = vehicle.Model?.ModelName,
                ReleaseYear = vehicle.ReleaseYear,
                RentalPrice = vehicle.RentalPrice,
                Transmission = vehicle.Transmission
            };
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetSingleAsync(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("მანქანა არ მოიძებნა");
            vehicle.Delete();
            _unitOfWork.VehicleRepository.Update(vehicle);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task ReactiveVehicle(int id)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetSingleAsync(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("მანქანა არ მოიძებნა");
            vehicle.ReActive();
            _unitOfWork.VehicleRepository.Update(vehicle);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

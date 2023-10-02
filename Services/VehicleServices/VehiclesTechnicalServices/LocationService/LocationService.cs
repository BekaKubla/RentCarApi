using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Persistence.Repositories.UnitOfWork;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.LocationService.Request;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.LocationService.Response;

namespace RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.LocationService
{
    public class LocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateLocation(CreateLocationRequest request)
        {
            var entity = VehicleLocation.CreateVehicleLocation(request.LocationName);
            await _unitOfWork.VehicleLocationRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<GetLocationResult> GetLocationById(int id)
        {
            var location = await _unitOfWork.VehicleLocationRepository.GetSingleAsync(x => x.Id == id && !x.IsDeleted) ??
                           throw new Exception("მისამართი არ მოიძებნა");

            return new GetLocationResult { Id = location.Id, LocationName = location.Location };
        }

        public async Task<List<GetLocationResult>> GetLocations(bool onlyActive)
        {
            var result = new List<GetLocationResult>();
            var locations = await _unitOfWork.VehicleLocationRepository.GetAllAsync() ??
                           throw new Exception("მისამართები ცარიელია");
            if (onlyActive)
            {
                locations = locations.Where(x => !x.IsDeleted).ToList();
            }

            foreach (var location in locations)
            {
                result.Add(new GetLocationResult { Id = location.Id, LocationName = location.Location, IsActive = !location.IsDeleted });
            }

            return result;
        }

        public async Task ReactiveLocation(int id)
        {
            var location = await _unitOfWork.VehicleLocationRepository.GetSingleAsync(x => x.Id == id && x.IsDeleted) ??
                           throw new Exception("მისამართი არ მოიძებნა");
            location.ReActive();
            _unitOfWork.VehicleLocationRepository.Update(location);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteLocation(int id)
        {
            var location = await _unitOfWork.VehicleLocationRepository.GetSingleAsync(x => x.Id == id && !x.IsDeleted) ??
                           throw new Exception("მისამართი არ მოიძებნა");

            var vehicles = (await _unitOfWork.VehicleRepository.GetAllAsync()).Where(x => x.VehicleLocationId == id).ToList();
            foreach (var vehicle in vehicles)
            {
                vehicle.DeleteVehicleLocation();
                _unitOfWork.VehicleRepository.Update(vehicle);
            };

            location.Delete();
            _unitOfWork.VehicleLocationRepository.Update(location);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

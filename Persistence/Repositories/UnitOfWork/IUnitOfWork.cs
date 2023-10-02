using RentCarApi.Persistence.Repositories.Vehicles.Base;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.Location;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleMark;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleModel;

namespace RentCarApi.Persistence.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IVehicleRepository VehicleRepository { get; }
        public IMarkRepository MarkRepository { get; }
        public IModelRepository ModelRepository { get; }
        public IVehicleLocationRepository VehicleLocationRepository { get; }
        Task<int> SaveChangeAsync();
    }
}

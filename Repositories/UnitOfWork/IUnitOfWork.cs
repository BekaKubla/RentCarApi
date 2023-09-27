using RentCarApi.Repositories.Vehicles.Base;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.Location;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleMark;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleModel;

namespace RentCarApi.Repositories.UnitOfWork
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

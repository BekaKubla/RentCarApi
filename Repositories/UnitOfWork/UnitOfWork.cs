using RentCarApi.Context;
using RentCarApi.Repositories.Vehicles.Base;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.Location;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleMark;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleModel;

namespace RentCarApi.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context,
                          IVehicleRepository vehicleRepository,
                          IMarkRepository markRepository,
                          IModelRepository modelRepository,
                          IVehicleLocationRepository vehicleLocationRepository)
        {
            _context = context;
            VehicleRepository = vehicleRepository;
            MarkRepository = markRepository;
            ModelRepository = modelRepository;
            VehicleLocationRepository = vehicleLocationRepository;
        }

        public IVehicleRepository VehicleRepository { get; }

        public IMarkRepository MarkRepository { get; }

        public IModelRepository ModelRepository { get; }

        public IVehicleLocationRepository VehicleLocationRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

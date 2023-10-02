using RentCarApi.Persistence.Context;
using RentCarApi.Persistence.Repositories.Vehicles.Base;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.Location;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleMark;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleModel;

namespace RentCarApi.Persistence.Repositories.UnitOfWork
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

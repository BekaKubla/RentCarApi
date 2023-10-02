using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Persistence.Context;
using RentCarApi.Persistence.Repositories.Generic;

namespace RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.Location
{
    public class VehicleLocationRepository : GenericRepository<VehicleLocation, AppDbContext>, IVehicleLocationRepository
    {
        public VehicleLocationRepository(AppDbContext context) : base(context)
        {

        }
    }
}

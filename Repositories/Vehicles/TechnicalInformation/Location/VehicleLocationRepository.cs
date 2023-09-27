using Microsoft.EntityFrameworkCore;
using RentCarApi.Context;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Repositories.Generic;

namespace RentCarApi.Repositories.Vehicles.TechnicalInformation.Location
{
    public class VehicleLocationRepository : GenericRepository<VehicleLocation, AppDbContext>, IVehicleLocationRepository
    {
        public VehicleLocationRepository(AppDbContext context) : base(context)
        {

        }
    }
}

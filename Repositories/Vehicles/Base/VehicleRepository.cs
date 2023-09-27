using Microsoft.EntityFrameworkCore;
using RentCarApi.Context;
using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Repositories.Generic;

namespace RentCarApi.Repositories.Vehicles.Base
{
    public class VehicleRepository : GenericRepository<Vehicle,AppDbContext>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context) : base(context)
        {
        }
    }
}

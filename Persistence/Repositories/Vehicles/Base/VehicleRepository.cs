using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Persistence.Context;
using RentCarApi.Persistence.Repositories.Generic;

namespace RentCarApi.Persistence.Repositories.Vehicles.Base
{
    public class VehicleRepository : GenericRepository<Vehicle, AppDbContext>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context) : base(context)
        {
        }
    }
}

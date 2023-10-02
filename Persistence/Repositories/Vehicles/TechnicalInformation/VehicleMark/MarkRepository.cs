using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Persistence.Context;
using RentCarApi.Persistence.Repositories.Generic;

namespace RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleMark
{
    public class MarkRepository : GenericRepository<Mark, AppDbContext>, IMarkRepository
    {
        public MarkRepository(AppDbContext context) : base(context)
        {
        }
    }
}

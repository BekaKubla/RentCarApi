using Microsoft.EntityFrameworkCore;
using RentCarApi.Context;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Repositories.Generic;

namespace RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleMark
{
    public class MarkRepository : GenericRepository<Mark, AppDbContext>, IMarkRepository
    {
        public MarkRepository(AppDbContext context) : base(context)
        {
        }
    }
}

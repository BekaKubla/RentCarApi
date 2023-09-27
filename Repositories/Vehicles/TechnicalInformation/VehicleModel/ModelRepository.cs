using Microsoft.EntityFrameworkCore;
using RentCarApi.Context;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Repositories.Generic;

namespace RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleModel
{
    public class ModelRepository : GenericRepository<Model, AppDbContext>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context) { }
    }
}

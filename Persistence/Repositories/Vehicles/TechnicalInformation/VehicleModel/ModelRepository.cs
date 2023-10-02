using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Persistence.Context;
using RentCarApi.Persistence.Repositories.Generic;

namespace RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleModel
{
    public class ModelRepository : GenericRepository<Model, AppDbContext>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context) { }
    }
}

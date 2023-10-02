using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Persistence.Repositories.Generic;

namespace RentCarApi.Persistence.Repositories.Vehicles.Base
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
    }
}

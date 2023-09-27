using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Repositories.Generic;

namespace RentCarApi.Repositories.Vehicles.Base
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
    }
}

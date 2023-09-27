using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Models;

namespace RentCarApi.Entities.Vehicles.TechnicalInformation
{
    public class VehicleLocation : MainEntity
    {
        public VehicleLocation(string location)
        {
            Location = location;
        }
        public string? Location { get; private set; }
        public IEnumerable<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public static VehicleLocation CreateVehicleLocation(string location)
        {
            return new VehicleLocation(location);
        }
    }
}

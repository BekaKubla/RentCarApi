using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Models;

namespace RentCarApi.Entities.Vehicles.TechnicalInformation
{
    public class Model : MainEntity
    {
        public Model(string modelName)
        {
            ModelName = modelName;
        }

        public string? ModelName { get; set; }

        public virtual IEnumerable<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        public static Model Create(string modelName)
        {
            return new Model(modelName);
        }
    }
}

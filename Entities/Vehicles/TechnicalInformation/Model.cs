using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Models;

namespace RentCarApi.Entities.Vehicles.TechnicalInformation
{
    public class Model : MainEntity
    {
        protected Model()
        {

        }
        public Model(string? modelName)
        {
            ModelName = modelName;
        }

        public string? ModelName { get; private set; }

        public int MarkId { get; private set; }
        public virtual Mark Mark { get; private set; }

        public virtual IEnumerable<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        public static Model Create(string? modelName)
        {
            return new Model(modelName);
        }
        public void AssignMark(Mark mark)
        {
            Mark = mark;
        }
    }
}

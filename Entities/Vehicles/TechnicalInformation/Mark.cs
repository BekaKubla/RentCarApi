using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Models;

namespace RentCarApi.Entities.Vehicles.TechnicalInformation
{
    public class Mark : MainEntity
    {
        public Mark(string markName)
        {
            MarkName = markName;
        }
        public string? MarkName { get; set; }

        public virtual IEnumerable<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        public Mark CreateMark(string markName)
        {
            return new Mark(markName);
        }
    }
}

using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Models;

namespace RentCarApi.Entities.Vehicles.TechnicalInformation
{
    public class Mark : MainEntity
    {
        public Mark(string? markName)
        {
            MarkName = markName;
        }

        public string? MarkName { get; private set; }


        public virtual IEnumerable<Model> Models { get; private set; } = new List<Model>();
        public virtual IEnumerable<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        public static Mark CreateMark(string? markName)
        {
            return new Mark(markName);
        }
    }
}

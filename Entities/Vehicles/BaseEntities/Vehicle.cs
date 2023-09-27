using RentCarApi.Entities.Vehicles.Enums;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Models;

namespace RentCarApi.Entities.Vehicles.BaseEntities
{
    public class Vehicle : MainEntity
    {
        protected Vehicle()
        {

        }
        public Vehicle(short seatCount, bool airCondition, short doorsCount, string luggagesCount, double rentalPrice, Transmission transmission, string? releaseYear, double engineVolume)
        {
            SeatCount = seatCount;
            AirCondition = airCondition;
            DoorsCount = doorsCount;
            LuggagesCount = luggagesCount;
            RentalPrice = rentalPrice;
            Transmission = transmission;
            ReleaseYear = releaseYear;
            EngineVolume = engineVolume;

        }

        public short SeatCount { get; private set; }
        public bool AirCondition { get; private set; }
        public short DoorsCount { get; private set; }
        public string? LuggagesCount { get; private set; }
        public double? RentalPrice { get; private set; }
        public Transmission Transmission { get; private set; }
        public string? ReleaseYear { get; private set; }
        public double EngineVolume { get; private set; }

        //<<<<<<<<---------------Relation Entities--------------->>>>>>>>
        public int MarkId { get; private set; }
        public virtual Mark? Mark { get; private set; }

        public int ModelId { get; private set; }
        public virtual Model? Model { get; private set; }

        public int VehicleLocationId { get; private set; }
        public virtual VehicleLocation? VehicleLocation { get; private set; }

        #region Methods
        public Vehicle CreateVehicle(short seatCount, bool airCondition, short doorsCount, string luggagesCount, double rentalPrice, Transmission transmission, string? releaseYear, double engineVolume)
        {
            return new Vehicle(seatCount, airCondition, doorsCount, luggagesCount, rentalPrice, transmission, releaseYear, engineVolume);
        }

        public void AssignMark(Mark mark)
        {
            Mark = mark;
        }
        public void AssignModel(Model model)
        {
            Model = model;
        }
        public void AssignLocation(VehicleLocation vehicleLocation)
        {
            VehicleLocation = vehicleLocation;
        }

        #endregion
    }
}

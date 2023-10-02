using RentCarApi.Entities.Vehicles.Enums;

namespace RentCarApi.Services.VehicleServices.VehicleService.Request
{
    public class CreateVehicleModel
    {
        public short SeatCount { get; set; }
        public bool AirCondition { get; set; }
        public short DoorsCount { get; set; }
        public string? LuggagesCount { get; set; }
        public double? RentalPrice { get; set; }
        public Transmission Transmission { get; set; }
        public string? ReleaseYear { get; set; }
        public double EngineVolume { get; set; }
        public int MarkId { get;  set; }
        public int ModelId { get;  set; }
        public int VehicleLocationId { get;  set; }
    }
}

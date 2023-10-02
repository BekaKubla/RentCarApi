using RentCarApi.Entities.Vehicles.Enums;

namespace RentCarApi.Services.VehicleServices.VehicleService.Response
{
    public class CreateVehicleResult
    {
        public string? MarkName { get; set; }
        public string? ModelName { get; set; }

        public short SeatCount { get; set; }
        public bool AirCondition { get; set; }
        public short DoorsCount { get; set; }
        public string? LuggagesCount { get; set; }
        public double? RentalPrice { get; set; }
        public Transmission Transmission { get; set; }
        public string? ReleaseYear { get; set; }
        public double EngineVolume { get; set; }
        public string? LocationName { get; set; }
    }
}

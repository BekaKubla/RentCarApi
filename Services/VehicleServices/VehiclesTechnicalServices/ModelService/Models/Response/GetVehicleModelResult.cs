namespace RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService.Models.Response
{
    public class GetVehicleModelResult
    {
        public int Id { get; set; }
        public string? MarkName { get; set; }
        public string? ModelName { get; set; }
        public bool? IsActive { get; set; }
    }
}

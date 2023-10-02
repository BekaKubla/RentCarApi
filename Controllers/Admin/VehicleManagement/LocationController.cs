using Microsoft.AspNetCore.Mvc;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.LocationService;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.LocationService.Request;

namespace RentCarApi.Controllers.Admin.VehicleManagement
{
    public class LocationController : Controller
    {
        private readonly LocationService _locationService;
        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost("CreateLocation")]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
        {
            await _locationService.CreateLocation(request);
            return Ok();
        }

        [HttpGet("GetLocationById")]
        public async Task<IActionResult> GetLocationById([FromQuery] int id)
        {
            var result = await _locationService.GetLocationById(id);
            return Ok(result);
        }

        [HttpGet("GetLocations")]
        public async Task<IActionResult> GetLocations([FromQuery] bool isActive)
        {
            var result = await _locationService.GetLocations(isActive);
            return Ok(result);
        }

        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation([FromQuery] int id)
        {
            await _locationService.DeleteLocation(id);
            return Ok();
        }

        [HttpPut("ReactiveLocation")]
        public async Task<IActionResult> ReactiveLocation([FromQuery] int id)
        {
            await _locationService.ReactiveLocation(id);
            return Ok();
        }

    }
}

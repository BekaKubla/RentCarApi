using Microsoft.AspNetCore.Mvc;
using RentCarApi.Services.VehicleServices.VehicleService;
using RentCarApi.Services.VehicleServices.VehicleService.Request;

namespace RentCarApi.Controllers.Admin.VehicleManagement
{
    [Route("api/VehicleManagement/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly VehiclesService _vehiclesService;
        public VehicleController(VehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        [HttpPost("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody]CreateVehicleModel request)
        {
            await _vehiclesService.CreateVehicle(request);
            return Ok();
        }

        [HttpGet("GetVehicles")]
        public async Task<IActionResult> GetVehicles([FromQuery]bool isActive)
        {
            var result = await _vehiclesService.GetVehicles(isActive);
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService.Models.Request;

namespace RentCarApi.Controllers.Admin.VehicleManagement
{
    [Route("api/VehicleManagement/[controller]")]
    [ApiController]
    public class ModelController : Controller
    {
        private readonly ModelService _modelService;
        public ModelController(ModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost("CreateModel")]
        public async Task<IActionResult> CreateModel([FromBody] CreateModelRequestModel request)
        {
            await _modelService.CreateModel(request);
            return Ok();
        }

        [HttpGet("GetModelById")]
        public async Task<IActionResult> GetModel([FromQuery] int id)
        {
            var result = await _modelService.GetModel(id);

            return Ok(result);
        }

        [HttpGet("GetModels")]
        public async Task<IActionResult> GetModels(bool isActive)
        {
            var result = await _modelService.GetModels(isActive);
            return Ok(result);
        }

        [HttpDelete("DeleteModel")]
        public async Task<IActionResult> DeleteModel([FromQuery] int id)
        {
            await _modelService.DeleteModel(id);
            return Ok();
        }

        [HttpPut("ReactiveModel")]
        public async Task<IActionResult> ReactiveModel([FromQuery] int id)
        {
            await _modelService.ReactiveModel(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.MarkService;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.MarkService.Request;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService.Models.Request;

namespace RentCarApi.Controllers.Admin.VehicleManagement
{
    [Route("api/VehicleManagement/[controller]")]
    [ApiController]
    public class MarkController : Controller
    {
        private readonly MarkServices _markServices;
        public MarkController(MarkServices markServices)
        {
            _markServices = markServices;
        }

        #region Marks
        [HttpPost("CreateMark")]
        public async Task<IActionResult> CreateMark([FromBody] CreateMarkRequestModel request)
        {
            await _markServices.CreateMark(request);
            return Ok();
        }

        [HttpGet("GetMarkByFilter")]
        public async Task<IActionResult> GetMarkByFilter([FromQuery] GetMarkModelsRequest request)
        {
            var result = await _markServices.GetMarkModelsWithFilter(request);
            return Ok(result);
        }

        [HttpGet("GetMarks")]
        public async Task<IActionResult> GetMarks(bool isActive)
        {
            var result = await _markServices.GetMarks(isActive);
            return Ok(result);
        }

        [HttpDelete("DeleteMark")]
        public async Task<IActionResult> DeleteMark([FromQuery] int id)
        {
            await _markServices.DeleteMark(id);
            return Ok();
        }

        [HttpPut("ReactiveMark")]
        public async Task<IActionResult> ReactiveMark([FromQuery] int id)
        {
            await _markServices.ReactiveMark(id);
            return Ok();
        }

        #endregion
    }
}

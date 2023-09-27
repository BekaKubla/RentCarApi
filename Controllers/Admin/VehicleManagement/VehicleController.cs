using Microsoft.AspNetCore.Mvc;
using RentCarApi.Entities.Vehicles.TechnicalInformation;
using RentCarApi.Repositories.UnitOfWork;

namespace RentCarApi.Controllers.Admin.VehicleManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("CreateMark")]
        public async Task<IActionResult> CreateMark(Mark mark)
        {
            await _unitOfWork.MarkRepository.AddAsync(mark);
            await _unitOfWork.SaveChangeAsync();

            return Ok();
        }


    }
}

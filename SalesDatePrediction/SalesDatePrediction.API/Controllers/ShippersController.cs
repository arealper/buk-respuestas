using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService _service;

        public ShippersController(IShipperService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}

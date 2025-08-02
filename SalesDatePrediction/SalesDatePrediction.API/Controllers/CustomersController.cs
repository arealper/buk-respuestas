using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("predictions")]
        public async Task<IActionResult> GetPredictions([FromQuery] string? search)
        {
            var result = await _service.GetCustomerPredictionsAsync();

            var filtered = string.IsNullOrWhiteSpace(search)
                ? result
                : result.Where(t => t.CustomerName!.Contains(search, StringComparison.InvariantCultureIgnoreCase));

            return Ok(filtered.ToList());
        }
    }
}

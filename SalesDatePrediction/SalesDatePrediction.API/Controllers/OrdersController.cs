using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var result = await _service.GetByCustomerIdAsync(customerId);

            if (result == null || !result.Any())
                return NotFound($"No orders found for customer with ID {customerId}");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]NewOrderDto order)
        {
            var orderId = await _service.CreateOrderAsync(order);
            return Ok(orderId);
        }
    }
}

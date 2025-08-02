using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetByCustomerIdAsync(int customerId);
        Task<int> CreateOrderAsync(NewOrderDto newOrder);
    }
}

using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetByCustomerIdAsync(int customerId);
        Task<int> CreateOrderAsync(NewOrderDto newOrder);
    }
}

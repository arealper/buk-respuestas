using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<OrderDto>> GetByCustomerIdAsync(int customerId)
        {
            return _repo.GetByCustomerIdAsync(customerId);
        }

        public Task<int> CreateOrderAsync(NewOrderDto newOrder)
        {
            return _repo.CreateOrderAsync(newOrder);
        }
    }
}

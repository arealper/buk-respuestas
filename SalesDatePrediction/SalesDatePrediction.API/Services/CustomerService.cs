using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<CustomerPredictionDto>> GetCustomerPredictionsAsync()
        {
            return _repo.GetCustomerPredictionsAsync();
        }
    }
}

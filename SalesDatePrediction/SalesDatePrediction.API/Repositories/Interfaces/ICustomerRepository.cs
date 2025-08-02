using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerPredictionDto>> GetCustomerPredictionsAsync();
    }
}

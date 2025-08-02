using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerPredictionDto>> GetCustomerPredictionsAsync();
    }
}

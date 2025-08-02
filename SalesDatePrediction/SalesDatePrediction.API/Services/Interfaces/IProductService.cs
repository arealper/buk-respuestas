using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}

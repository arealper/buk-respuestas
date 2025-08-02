using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}

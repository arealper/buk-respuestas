using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }
    }

}

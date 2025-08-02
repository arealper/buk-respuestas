using Dapper;
using SalesDatePrediction.API.Context;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using System.Data;

namespace SalesDatePrediction.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var products = await connection.QueryAsync<ProductDto>(
                "Production.GetProducts",
                commandType: CommandType.StoredProcedure
            );
            return products;
        }
    }

}

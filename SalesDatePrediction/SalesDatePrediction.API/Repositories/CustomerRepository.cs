using Dapper;
using SalesDatePrediction.API.Context;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using System.Data;

namespace SalesDatePrediction.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerPredictionDto>> GetCustomerPredictionsAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<CustomerPredictionDto>(
                "Sales.SalesDatePrediction",
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

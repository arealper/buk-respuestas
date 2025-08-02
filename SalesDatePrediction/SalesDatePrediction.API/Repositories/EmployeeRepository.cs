using Dapper;
using SalesDatePrediction.API.Context;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using System.Data;

namespace SalesDatePrediction.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var sql = "HR.GetEmployees";

            return await connection.QueryAsync<EmployeeDto>(
                sql,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

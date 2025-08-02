using Dapper;
using SalesDatePrediction.API.Context;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using System.Data;

namespace SalesDatePrediction.API.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly DapperContext _context;

        public ShipperRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipperDto>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var sql = "Sales.GetShippers";
            return await connection.QueryAsync<ShipperDto>(sql, commandType: CommandType.StoredProcedure);
        }
    }

}

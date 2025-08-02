using Dapper;
using SalesDatePrediction.API.Context;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using System.Data;

namespace SalesDatePrediction.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _context;

        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetByCustomerIdAsync(int customerId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<OrderDto>(
                "Sales.GetClientOrders",
                new { CustomerId = customerId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> CreateOrderAsync(NewOrderDto newOrder)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", newOrder.CustomerID);
            parameters.Add("EmpID", newOrder.EmployeeID);
            parameters.Add("ShipperID", newOrder.ShipperID);
            parameters.Add("ShipName", newOrder.ShipName);
            parameters.Add("ShipAddress", newOrder.ShipAddress);
            parameters.Add("ShipCity", newOrder.ShipCity);
            parameters.Add("OrderDate", newOrder.OrderDate);
            parameters.Add("RequiredDate", newOrder.RequiredDate);
            parameters.Add("ShippedDate", newOrder.ShippedDate);
            parameters.Add("Freight", newOrder.Freight);
            parameters.Add("ShipCountry", newOrder.ShipCountry);

            // solo 1 producto
            var product = newOrder.Product;
            parameters.Add("ProductID", product!.ProductID);
            parameters.Add("UnitPrice", product.UnitPrice);
            parameters.Add("Qty", product.Qty);
            parameters.Add("Discount", product.Discount);

            parameters.Add("@OrderId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "Sales.AddNewOrder",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("@OrderId");
        }
    }
}

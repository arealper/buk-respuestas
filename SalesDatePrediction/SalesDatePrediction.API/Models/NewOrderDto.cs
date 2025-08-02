namespace SalesDatePrediction.API.Models
{
    public class NewOrderDto
    {
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int ShipperID { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string? ShipCountry { get; set; }

        public NewOrderItemDto? Product { get; set; }
    }
}

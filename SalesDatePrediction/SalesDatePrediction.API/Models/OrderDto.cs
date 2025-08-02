namespace SalesDatePrediction.API.Models
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
    }
}

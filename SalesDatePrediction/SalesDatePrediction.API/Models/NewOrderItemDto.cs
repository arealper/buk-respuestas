namespace SalesDatePrediction.API.Models
{
    public class NewOrderItemDto
    {
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }
        public float Discount { get; set; }
    }
}

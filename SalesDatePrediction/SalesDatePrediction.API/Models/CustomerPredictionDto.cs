﻿namespace SalesDatePrediction.API.Models
{
    public class CustomerPredictionDto
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }
}

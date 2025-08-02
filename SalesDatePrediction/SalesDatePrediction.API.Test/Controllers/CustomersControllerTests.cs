using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.API.Controllers;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Test.Controllers
{
    public class CustomersControllerTests
    {
        [Fact]
        public async Task GetPredictions_ReturnsOkResult_WithData()
        {
            // Arrange
            var mockService = new Mock<ICustomerService>();
            var fakeResult = new List<CustomerPredictionDto> { 
                new() { 
                    CustomerName = "001",
                    LastOrderDate = DateTime.Now,
                    NextPredictedOrder    = DateTime.Now.AddDays(1)
                },
                new() {
                    CustomerName = "002",
                    LastOrderDate = DateTime.Now,
                    NextPredictedOrder    = DateTime.Now.AddDays(1)
                }
            };
            mockService.Setup(s => s.GetCustomerPredictionsAsync())
                       .ReturnsAsync(fakeResult);

            var controller = new CustomersController(mockService.Object);

            // Act
            var result = await controller.GetPredictions(null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedValue = Assert.IsType<IEnumerable<CustomerPredictionDto>>(okResult.Value, exactMatch: false);
            Assert.Equal(2, ((List<CustomerPredictionDto>)returnedValue).Count);
        }
    }
}

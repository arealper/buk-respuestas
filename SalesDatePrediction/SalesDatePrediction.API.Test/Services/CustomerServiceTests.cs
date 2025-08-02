using Moq;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services;

namespace SalesDatePrediction.API.Test.Services
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task GetCustomerPredictionsAsync_ReturnsExpectedPredictions()
        {
            // Arrange
            var mockRepo = new Mock<ICustomerRepository>();
            var expectedPredictions = new List<CustomerPredictionDto> {
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

            mockRepo.Setup(r => r.GetCustomerPredictionsAsync())
                    .ReturnsAsync(expectedPredictions);

            var service = new CustomerService(mockRepo.Object);

            // Act
            var result = await service.GetCustomerPredictionsAsync();

            // Assert
            Assert.Equal(expectedPredictions, result);
        }
    }
}

using Moq;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services;

namespace SalesDatePrediction.API.Test.Services
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsEmployeeDtos()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var employees = new List<EmployeeDto>
            {
                new() { EmployeeID = 1, FullName = "John Doe" },
                new() { EmployeeID = 2, FullName = "Jane Smith" }
            };

            mockRepo.Setup(r => r.GetAllAsync())
                    .ReturnsAsync(employees);

            var service = new EmployeeService(mockRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            var list = result.ToList();
            Assert.Equal(2, list.Count);
            Assert.Equal("John Doe", list[0].FullName);
            Assert.Equal("Jane Smith", list[1].FullName);
        }
    }
}

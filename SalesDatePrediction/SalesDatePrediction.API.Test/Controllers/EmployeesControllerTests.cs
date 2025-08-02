using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.API.Controllers;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Test.Controllers
{
    public class EmployeesControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            var mockService = new Mock<IEmployeeService>();
            var expectedEmployees = new List<EmployeeDto>
            {
                new() { EmployeeID = 1, FullName = "John Doe" },
                new() { EmployeeID = 2, FullName = "Jane Smith" }
            };

            mockService.Setup(s => s.GetAllAsync())
                       .ReturnsAsync(expectedEmployees);

            var controller = new EmployeesController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<EmployeeDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
}

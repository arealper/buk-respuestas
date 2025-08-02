using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.API.Controllers;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Test.Controllers
{
    public class ShippersControllerTests
    {
        private readonly Mock<IShipperService> _serviceMock;
        private readonly ShippersController _controller;

        public ShippersControllerTests()
        {
            _serviceMock = new Mock<IShipperService>();
            _controller = new ShippersController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithShipperList()
        {
            // Arrange
            var shippers = new List<ShipperDto>
        {
            new ShipperDto { ShipperID = 1, CompanyName = "DHL" },
            new ShipperDto { ShipperID = 2, CompanyName = "FedEx" }
        };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(shippers);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returned = Assert.IsAssignableFrom<IEnumerable<ShipperDto>>(okResult.Value);
            Assert.Equal(2, returned.Count());
        }
    }

}

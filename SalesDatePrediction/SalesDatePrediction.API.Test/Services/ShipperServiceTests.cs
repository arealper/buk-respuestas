using Moq;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services;

namespace SalesDatePrediction.API.Test.Services
{
    public class ShipperServiceTests
    {
        private readonly Mock<IShipperRepository> _repoMock;
        private readonly ShipperService _service;

        public ShipperServiceTests()
        {
            _repoMock = new Mock<IShipperRepository>();
            _service = new ShipperService(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOfShippers()
        {
            // Arrange
            var shippers = new List<ShipperDto>
        {
            new ShipperDto { ShipperID = 1, CompanyName = "DHL" },
            new ShipperDto { ShipperID = 2, CompanyName = "FedEx" }
        };
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(shippers);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, s => s.CompanyName == "DHL");
        }
    }

}

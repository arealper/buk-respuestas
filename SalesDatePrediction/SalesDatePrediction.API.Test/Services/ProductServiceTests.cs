using Moq;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services;

namespace SalesDatePrediction.API.Test.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _repositoryMock;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _service = new ProductService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOfProducts()
        {
            // Arrange
            var products = new List<ProductDto>
        {
            new ProductDto { ProductID = 1, ProductName = "Product A" },
            new ProductDto { ProductID = 2, ProductName = "Product B" }
        };
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Product A", result.First().ProductName);
        }
    }

}

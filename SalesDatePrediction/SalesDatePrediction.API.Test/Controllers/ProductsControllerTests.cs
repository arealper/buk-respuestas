using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.API.Controllers;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Services.Interfaces;

public class ProductsControllerTests
{
    private readonly Mock<IProductService> _serviceMock;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _serviceMock = new Mock<IProductService>();
        _controller = new ProductsController(_serviceMock.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithProductList()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { ProductID = 1, ProductName = "Product A" },
            new() { ProductID = 2, ProductName = "Product B" }
        };
        _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(products);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedProducts = Assert.IsType<IEnumerable<ProductDto>>(okResult.Value, exactMatch: false);
        Assert.Equal(2, returnedProducts.Count());
    }
}

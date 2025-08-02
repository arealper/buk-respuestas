using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.API.Controllers;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Services.Interfaces;

public class OrdersControllerTests
{
    private readonly OrdersController _controller;
    private readonly Mock<IOrderService> _serviceMock;

    public OrdersControllerTests()
    {
        _serviceMock = new Mock<IOrderService>();
        _controller = new OrdersController(_serviceMock.Object);
    }

    [Fact]
    public async Task GetByCustomerId_ReturnsOk_WhenOrdersExist()
    {
        var customerId = 1;
        var orders = new List<OrderDto> { new OrderDto {  OrderID = 1 } };
        _serviceMock.Setup(s => s.GetByCustomerIdAsync(customerId)).ReturnsAsync(orders);

        var result = await _controller.GetByCustomerId(customerId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal(orders, okResult.Value);
    }

    [Fact]
    public async Task GetByCustomerId_ReturnsNotFound_WhenNoOrders()
    {
        var customerId = 1;
        _serviceMock.Setup(s => s.GetByCustomerIdAsync(customerId)).ReturnsAsync(new List<OrderDto>());

        var result = await _controller.GetByCustomerId(customerId);

        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(404, notFound.StatusCode);
    }

    [Fact]
    public async Task Create_ReturnsOk_WithOrderId()
    {
        var dto = new NewOrderDto { CustomerID = 1 };
        _serviceMock.Setup(s => s.CreateOrderAsync(dto)).ReturnsAsync(42);

        var result = await _controller.Create(dto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(42, okResult.Value);
    }
}

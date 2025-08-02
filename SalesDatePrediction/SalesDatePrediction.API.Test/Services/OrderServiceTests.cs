using Moq;
using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services;

public class OrderServiceTests
{
    private readonly OrderService _service;
    private readonly Mock<IOrderRepository> _repoMock;

    public OrderServiceTests()
    {
        _repoMock = new Mock<IOrderRepository>();
        _service = new OrderService(_repoMock.Object);
    }

    [Fact]
    public async Task GetByCustomerIdAsync_ReturnsOrders()
    {
        var customerId = 1;
        var orders = new List<OrderDto> { new OrderDto { OrderID = 1 } };
        _repoMock.Setup(r => r.GetByCustomerIdAsync(customerId)).ReturnsAsync(orders);

        var result = await _service.GetByCustomerIdAsync(customerId);

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task CreateOrderAsync_ReturnsOrderId()
    {
        var dto = new NewOrderDto { CustomerID = 1 };
        _repoMock.Setup(r => r.CreateOrderAsync(It.IsAny<NewOrderDto>())).ReturnsAsync(10);

        var result = await _service.CreateOrderAsync(dto);

        Assert.Equal(10, result);
    }
}

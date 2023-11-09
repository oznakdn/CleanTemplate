using Clean.Domain.OrderItems;
using Clean.Domain.Orders;
using Clean.Domain.Shared;

namespace DomainTests;

public class OrderTests
{

    Guid CustomerId {get;set;} = Guid.NewGuid();
    Guid ProductId {get;set;} = Guid.NewGuid();

    [Fact]
    public void CreateOrder_Should_Not_Be_Null()
    {
        var order = new Order(CustomerId);
        Assert.NotNull(order);
    }

    [Fact]
    public void AddOrderItem_ShouldBe_Return_Successed()
    {
        var order = new Order(CustomerId);
        TResult<OrderItem> orderResult = order.AddOrderItem(ProductId,1);
        Assert.True(orderResult.IsSuccessed);
        Assert.IsType(typeof(Guid),orderResult.Value.OrderId);
    }

     [Fact]
    public void AddOrderIte_When_QuantityEqualOrLess_Than_Zero_ShouldBe_Return_Failed()
    {
        var order = new Order(CustomerId);
        TResult<OrderItem> orderResult = order.AddOrderItem(ProductId,-1);
        Assert.True(orderResult.IsFailed);
    }
}
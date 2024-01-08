using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.OrderItems;
using Clean.Domain.Orders.Enums;
using Clean.Shared;

namespace Clean.Domain.Orders;

public class Order : AggregateRoot<Order, Guid>
{
    private List<OrderItem> _orderItems = new();
    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;


    public Order(Guid customerId) : base(Guid.NewGuid())
    {
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
    }

    private Order() : base(Guid.Empty) { }

    public IResult<OrderItem> AddOrderItem(Guid productId, int quantity)
    {
        if (quantity <= 0)
        {
            return Result<OrderItem>.Fail($"Quantity should be greater than 0!");
        }

        OrderItem? orderItem = new OrderItem(productId, this.Id, quantity);
        _orderItems.Add(orderItem);
        return Result<OrderItem>.Success(value: orderItem);
    }

    public void PaymentRecived()
    {
        Status = OrderStatus.PaymentReveived;
    }

    public void PaymentFailed()
    {
        Status = OrderStatus.PaymentFailed;
    }
    public void InProgress()
    {
        Status = OrderStatus.InProgress;
    }

    public void Completed()
    {
        Status = OrderStatus.Completed;
    }

    public void Canceled()
    {
        Status = OrderStatus.Canceled;
    }

}

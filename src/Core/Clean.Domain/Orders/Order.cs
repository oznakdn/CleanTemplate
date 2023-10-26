using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Orders;

public class Order : AggregateRoot<Order,Guid>
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

    public void AddOrderItem(Guid productId, int quantity)
    {
        _orderItems.Add(new OrderItem(productId, quantity));
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

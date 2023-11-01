using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Shared;

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

    public TResult<OrderItem> AddOrderItem(Guid productId, int quantity)
    {
        if(quantity<=0)
        {
            return TResult<OrderItem>.Fail($"Quantity should be greater than 0!");
        }
         var orderItem = new OrderItem(productId,this.Id, quantity);
        _orderItems.Add(orderItem);
        return TResult<OrderItem>.Ok(orderItem);
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

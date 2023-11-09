using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Orders;

namespace Clean.Domain.OrderItems;

public class OrderItem : Entity<Guid>
{
    public Guid ProductId { get; private set; }
    public Guid OrderId { get; private set; }
    public int Quantity { get; private set; }
    public decimal TotalAmount { get; }
    public Order Order { get; private set; }

    public OrderItem(Guid productId, Guid orderId, int quantity) : base(Guid.NewGuid())
    {
        ProductId = productId;
        Quantity = quantity;
        OrderId = orderId;
    }

    private OrderItem() : base(Guid.Empty) { }

}

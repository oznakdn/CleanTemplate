using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.OrderItems.Events;

public class CreateOrderItemEvent : IDomaintEvent
{
    public CreateOrderItemEvent(Guid basketId, Guid orderId)
    {
        BasketId = basketId;
        OrderId = orderId;
    }

    public Guid BasketId { get; set; }
    public Guid OrderId { get; set; }
    public OrderItem OrderItem { get; set; }
}

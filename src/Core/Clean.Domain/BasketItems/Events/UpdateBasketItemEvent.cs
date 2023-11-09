using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.BasketItems.Events;

public class UpdateBasketItemEvent : IDomaintEvent
{
    public UpdateBasketItemEvent(Guid basketItemId, int quantity)
    {
        BasketItemId = basketItemId;
        Quantity = quantity;
    }

    public Guid BasketItemId { get; set; }
    public int Quantity { get; set; }
    public BasketItem BasketItem { get; set; }
}

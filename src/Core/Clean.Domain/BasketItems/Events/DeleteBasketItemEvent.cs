using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.BasketItems.Events;

public class DeleteBasketItemEvent : IDomaintEvent
{
    public DeleteBasketItemEvent(Guid basketId, Guid basketItemId)
    {
        BasketId = basketId;
        BasketItemId = basketItemId;
    }

    public Guid BasketId { get; set; }
    public Guid BasketItemId { get; set; }
    public BasketItem BasketItem { get; set; }
}

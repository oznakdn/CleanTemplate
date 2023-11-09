using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.BasketItems.Events;

public class DeletedBasketItemsEvent : IDomaintEvent
{
    public Guid BasketId { get; set; }
    public List<BasketItem> BasketItems { get; set; }

    public DeletedBasketItemsEvent(Guid basketId)
    {
        BasketId = basketId;
    }
}

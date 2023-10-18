using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Commands.UpdateBasket;



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

public class UpdateBasketItemEventHandler : DomainEventHandler<UpdateBasketItemEvent, BasketItem>
{
    private readonly IBasketItemRepository _basketItem;

    public UpdateBasketItemEventHandler(IBasketItemRepository basketItem)
    {
        _basketItem = basketItem;
    }

    protected override async Task<BasketItem> Handle(UpdateBasketItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            @event.BasketItem = _basketItem.Get(x => x.Id == e.BasketItemId);
            @event.BasketItem.UpdateQuantity(e.Quantity);
        };

        EventInvoke(@event);
        _basketItem.Update(@event.BasketItem);
        await Task.CompletedTask;
        return @event.BasketItem;
    }
}

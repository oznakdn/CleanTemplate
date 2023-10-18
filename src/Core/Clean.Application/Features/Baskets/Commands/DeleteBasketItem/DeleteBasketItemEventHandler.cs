using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Commands.DeleteBasketItem;


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

public class DeleteBasketItemEventHandler : DomainEventHandler<DeleteBasketItemEvent, BasketItem>
{
    private readonly IBasketItemRepository _basketItem;

    public DeleteBasketItemEventHandler(IBasketItemRepository basketItem)
    {
        _basketItem = basketItem;
    }

    protected async override Task<BasketItem> Handle(DeleteBasketItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            @event.BasketItem = _basketItem.GetAsync(cancellationToken,
                                x => x.BasketId == e.BasketId &&
                               x.Id == e.BasketItemId).Result;
            _basketItem.Delete(@event.BasketItem);
        };

        EventInvoke(@event);
        await Task.CompletedTask;
        return @event.BasketItem;
    }
}

using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

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
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public UpdateBasketItemEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected override async Task<BasketItem> Handle(UpdateBasketItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            @event.BasketItem = _query.BasketItem.ReadSingleOrDefault(true,x => x.Id == e.BasketItemId);
            @event.BasketItem.UpdateQuantity(e.Quantity);
        };

        EventInvoke(@event);
        _command.BasketItem.Edit(@event.BasketItem);
        await Task.CompletedTask;
        return @event.BasketItem;
    }
}

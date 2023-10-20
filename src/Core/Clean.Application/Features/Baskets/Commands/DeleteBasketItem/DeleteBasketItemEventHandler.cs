using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

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
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public DeleteBasketItemEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected async override Task<BasketItem> Handle(DeleteBasketItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            @event.BasketItem = _query.BasketItem.ReadSingleOrDefault(true,
                                x => x.BasketId == e.BasketId &&
                               x.Id == e.BasketItemId);
            _command.BasketItem.Remove(@event.BasketItem);
        };

        EventInvoke(@event);
        await Task.CompletedTask;
        return @event.BasketItem;
    }
}

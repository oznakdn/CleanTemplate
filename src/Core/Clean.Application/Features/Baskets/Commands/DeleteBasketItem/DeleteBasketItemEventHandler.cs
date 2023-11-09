using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Events;
using Clean.Domain.Contracts.Abstracts;

namespace Clean.Application.Features.Baskets.Commands.DeleteBasketItem;


public class DeleteBasketItemEventHandler : DomainEventHandler<DeleteBasketItemEvent, BasketItem>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public DeleteBasketItemEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected override BasketItem Handle(DeleteBasketItemEvent @event)
    {
        Event += (s, e) =>
        {
            @event.BasketItem = _query.BasketItem.ReadSingleOrDefault(true,
                                x => x.BasketId == e.BasketId &&
                               x.Id == e.BasketItemId);
            _command.BasketItem.Remove(@event.BasketItem);
        };

        EventInvoke(@event);
        return @event.BasketItem;
    }

    protected override async Task<BasketItem> HandleAsync(DeleteBasketItemEvent @event, CancellationToken cancellationToken)
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

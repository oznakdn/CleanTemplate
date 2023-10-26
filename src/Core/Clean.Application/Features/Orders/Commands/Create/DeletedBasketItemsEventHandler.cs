using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Application.Features.Orders.Commands.Create;

public class DeletedBasketItemsEvent : IDomaintEvent
{
    public Guid BasketId { get; set; }
    public List<BasketItem> BasketItems { get; set; }

    public DeletedBasketItemsEvent(Guid basketId)
    {
        BasketId = basketId;
    }
}
public class DeletedBasketItemsEventHandler : DomainEventHandler<DeletedBasketItemsEvent,IList<BasketItem>>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public DeletedBasketItemsEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected async override Task<IList<BasketItem>> Handle(DeletedBasketItemsEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            @event.BasketItems = _query.BasketItem.ReadAll(true, filter: x => x.BasketId == e.BasketId).ToList();
        };

        EventInvoke(@event);
        _command.BasketItem.RemoveRange(@event.BasketItems);
        await Task.CompletedTask;
        return @event.BasketItems;

    }
}

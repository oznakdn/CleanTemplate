using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Events;
using Clean.Domain.Contracts.Abstracts;

namespace Clean.Application.Features.Baskets.Commands.UpdateBasket;



public class UpdateBasketItemEventHandler : DomainEventHandler<UpdateBasketItemEvent, BasketItem>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public UpdateBasketItemEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected override BasketItem Handle(UpdateBasketItemEvent @event)
    {
        Event += (s, e) =>
        {
            e.BasketItem = _query.BasketItem.ReadSingleOrDefault(true, x => x.Id == e.BasketItemId);
            e.BasketItem.UpdateQuantity(e.Quantity);
        };

        EventInvoke(@event);
        if (@event.BasketItem.ProductQuantity == 0)
        {
            _command.BasketItem.Remove(@event.BasketItem);
        }
        else
        {
            _command.BasketItem.Edit(@event.BasketItem);
        }

        return @event.BasketItem;
    }

    protected override async Task<BasketItem> HandleAsync(UpdateBasketItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            e.BasketItem = _query.BasketItem.ReadSingleOrDefault(true, x => x.Id == e.BasketItemId);
            e.BasketItem.UpdateQuantity(e.Quantity);
        };

        EventInvoke(@event);
        if (@event.BasketItem.ProductQuantity == 0)
        {
            _command.BasketItem.Remove(@event.BasketItem);
        }
        else
        {
            _command.BasketItem.Edit(@event.BasketItem);
        }

        await Task.CompletedTask;
        return @event.BasketItem;
    }

}

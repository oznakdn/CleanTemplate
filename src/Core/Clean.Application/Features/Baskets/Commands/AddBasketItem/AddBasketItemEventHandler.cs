using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Events;
using Clean.Domain.Contracts.Abstracts;

namespace Clean.Application.Features.Baskets.Commands.AddBasketItem;


public class AddBasketItemEventHandler : DomainEventHandler<AddBasketItemEvent, BasketItem>
{
    private readonly ICommandUnitOfWork _command;

    public AddBasketItemEventHandler(ICommandUnitOfWork command)
    {
        _command = command;
    }

    protected override BasketItem Handle(AddBasketItemEvent @event)
    {
        Event += (s, e) => _command.BasketItem.Insert(@event.BasketItem =
           new BasketItem(e.Basket.Id, e.Product.Id, e.Quantity, e.Product.Price.Amount));
        EventInvoke(@event);
        return @event.BasketItem;
    }

}

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

    protected override async Task<BasketItem> Handle(AddBasketItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) => _command.BasketItem.Insert(@event.BasketItem =
            new BasketItem(e.Basket.Id, e.Product.Id, e.Quantity, e.Product.Price.Amount));
        EventInvoke(@event);
        await Task.CompletedTask;
        return @event.BasketItem;
    }
}

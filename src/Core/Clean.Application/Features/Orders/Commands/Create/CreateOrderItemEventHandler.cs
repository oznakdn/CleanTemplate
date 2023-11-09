using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.OrderItems;
using Clean.Domain.OrderItems.Events;

namespace Clean.Application.Features.Orders.Commands.Create;

public class CreateOrderItemEventHandler : DomainEventHandler<CreateOrderItemEvent, OrderItem>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;
    public CreateOrderItemEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected async override Task<OrderItem> Handle(CreateOrderItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            var basketItems = _query.BasketItem.ReadAll(
                               noTracking: true,
                               filter: x => x.BasketId == e.BasketId);
            foreach (var item in basketItems)
            {
                _command.OrderItem.Create(@event.OrderItem = new OrderItem(item.ProductId, e.OrderId, item.ProductQuantity));
            }
        };

        EventInvoke(@event);
        await Task.CompletedTask;
        return @event.OrderItem;
    }
}

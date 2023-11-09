using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Inventories;

namespace Clean.Application.Features.Baskets.Commands.AddBasketItem;

public class UpdateInventoryEvent : IDomaintEvent
{
    public UpdateInventoryEvent(Guid prodcutId, int quantity)
    {
        ProdcutId = prodcutId;
        Quantity = quantity;
    }

    public Guid ProdcutId { get; set; }
    public Inventory Inventory { get; set; }
    public int Quantity { get; set; }
}


public class UpdateInventoryEventHandler : DomainEventHandler<UpdateInventoryEvent, Inventory>
{

    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public UpdateInventoryEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected override Inventory Handle(UpdateInventoryEvent @event)
    {
        Event += (s, e) =>
        {
            @event.Inventory = _query.Inventory.ReadSingleOrDefault(true, x => x.ProductId == e.ProdcutId);
            @event.Inventory.DecreaseStock(e.Quantity);
        };

        EventInvoke(@event);
        _command.Inventory.Edit(@event.Inventory);
        return @event.Inventory;
    }

    protected override async Task<Inventory> HandleAsync(UpdateInventoryEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            @event.Inventory = _query.Inventory.ReadSingleOrDefault(true, x => x.ProductId == e.ProdcutId);
            @event.Inventory.DecreaseStock(e.Quantity);
        };

        EventInvoke(@event);
        _command.Inventory.Edit(@event.Inventory);
        await Task.CompletedTask;
        return @event.Inventory;
    }
}

using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Products;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Products.Commands.Create;

public class AddInventoryEvent: IDomaintEvent
{
    public AddInventoryEvent(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public Inventory Inventory { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}


public class AddInventoryEventHandler : DomainEventHandler<AddInventoryEvent, Inventory>
{
    private readonly IInventoryRepository _inventory;

    public AddInventoryEventHandler(IInventoryRepository inventory)
    {
        _inventory = inventory;
    }

    protected override async Task<Inventory> Handle(AddInventoryEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) => _inventory.Insert(@event.Inventory = new Inventory(e.ProductId, e.Quantity));
        this.OnStarted(@event);
        await Task.CompletedTask;
        return @event.Inventory;
    }
}

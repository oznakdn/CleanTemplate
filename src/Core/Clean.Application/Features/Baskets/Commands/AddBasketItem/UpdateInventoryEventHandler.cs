using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Products;
using Clean.Domain.Repositories;

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
    private readonly IInventoryRepository _inventory;

    public UpdateInventoryEventHandler(IInventoryRepository inventory)
    {
        _inventory = inventory;
    }

    protected async override Task<Inventory> Handle(UpdateInventoryEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            @event.Inventory = _inventory.GetAsync(cancellationToken, x => x.ProductId == e.ProdcutId).Result;
            @event.Inventory.DecreaseStock(e.Quantity);
        };

        EventInvoke(@event);
        _inventory.Update(@event.Inventory);
        await Task.CompletedTask;
        return @event.Inventory;
    }
}

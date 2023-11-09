using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Inventories;

namespace Clean.Application.Features.Products.Commands.Create;

public class AddInventoryEvent : IDomaintEvent
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
    private readonly ICommandUnitOfWork _command;

    public AddInventoryEventHandler(ICommandUnitOfWork command)
    {
        _command = command;
    }

    protected override Inventory Handle(AddInventoryEvent @event)
    {
        Event += (s, e) => _command.Inventory.Insert(@event.Inventory = new Inventory(e.ProductId, e.Quantity));
        this.EventInvoke(@event);
        return @event.Inventory;
    }

}

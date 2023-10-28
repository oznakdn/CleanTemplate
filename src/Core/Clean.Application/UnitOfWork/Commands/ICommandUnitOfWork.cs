using Clean.Domain.Repositories.Commands;

namespace Clean.Application.UnitOfWork.Commands;

public interface ICommandUnitOfWork
{
    IBasketItemCommand BasketItem { get; }
    IBasketCommand Basket { get; }
    ICustomerCommand Customer { get; }
    IProductCommand Product { get; }
    IInventoryCommand Inventory { get; }
    IOrderCommand Order { get; }
    IOrderItemCommand OrderItem { get; }

}

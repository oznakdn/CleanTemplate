using Clean.Domain.BasketItems.Repositories;
using Clean.Domain.Baskets.Repositories;
using Clean.Domain.Customers.Repositories;
using Clean.Domain.Inventories.Repositories;
using Clean.Domain.OrderItems.Repositories;
using Clean.Domain.Orders.Repositories;
using Clean.Domain.Products.Repositories;

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

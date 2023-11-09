using Clean.Domain.BasketItems.Repositories;
using Clean.Domain.Baskets.Repositories;
using Clean.Domain.Customers.Repositories;
using Clean.Domain.Inventories.Repositories;
using Clean.Domain.OrderItems.Repositories;
using Clean.Domain.Orders.Repositories;
using Clean.Domain.Products.Repositories;

namespace Clean.Application.UnitOfWork.Queries;

public interface IQueryUnitOfWork
{
    IBasketItemQuery BasketItem { get; }
    IBasketQuery Basket { get; }
    ICustomerQuery Customer { get; }
    IProductQuery Product { get; }
    IInventoryQuery Inventory { get; }
    IOrderQuery Order { get; }
    IOrderItemQuery OrderItem { get; }
}

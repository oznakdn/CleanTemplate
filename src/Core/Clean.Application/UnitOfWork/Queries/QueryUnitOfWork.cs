using Clean.Domain.BasketItems.Repositories;
using Clean.Domain.Baskets.Repositories;
using Clean.Domain.Customers.Repositories;
using Clean.Domain.Inventories.Repositories;
using Clean.Domain.OrderItems.Repositories;
using Clean.Domain.Orders.Repositories;
using Clean.Domain.Products.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Queries;

namespace Clean.Application.UnitOfWork.Queries;

public class QueryUnitOfWork : IQueryUnitOfWork
{

    private readonly EFContext _context;

    public QueryUnitOfWork(EFContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        BasketItem = BasketItem ?? new BasketItemQuery(_context);
        Basket = Basket ?? new BasketQuery(_context);
        Customer = Customer ?? new CustomerQuery(_context);
        Product = Product ?? new ProductQuery(_context);
        Inventory = Inventory ?? new InventoryQuery(_context);
        Order = Order ?? new OrderQuery(_context);
        OrderItem = OrderItem ?? new OrderItemQuery(_context);
    }

    public IBasketItemQuery BasketItem { get; }

    public IBasketQuery Basket { get; }

    public ICustomerQuery Customer { get; }

    public IProductQuery Product { get; }

    public IInventoryQuery Inventory { get; }

    public IOrderQuery Order { get; }

    public IOrderItemQuery OrderItem { get; }

}

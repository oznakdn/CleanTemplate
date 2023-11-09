using Clean.Domain.BasketItems.Repositories;
using Clean.Domain.Baskets.Repositories;
using Clean.Domain.Customers.Repositories;
using Clean.Domain.Inventories.Repositories;
using Clean.Domain.OrderItems.Repositories;
using Clean.Domain.Orders.Repositories;
using Clean.Domain.Products.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Commands;

namespace Clean.Application.UnitOfWork.Commands;

public class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly EFContext _context;
    public CommandUnitOfWork(EFContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        BasketItem = BasketItem ?? new BasketItemCommand(_context);
        Basket = Basket ?? new BasketCommand(_context);
        Customer = Customer ?? new CustomerCommand(_context);
        Product = Product ?? new ProductCommand(_context);
        Inventory = Inventory ?? new InventoryCommand(_context);
        Order = Order ?? new OrderCommand(_context);
        OrderItem = OrderItem ?? new OrderItemCommand(_context);
    }


    public IBasketItemCommand BasketItem { get; }
    public IBasketCommand Basket { get; }
    public ICustomerCommand Customer { get; }
    public IProductCommand Product { get; }
    public IInventoryCommand Inventory { get; }
    public IOrderCommand Order { get; }
    public IOrderItemCommand OrderItem { get; }
}

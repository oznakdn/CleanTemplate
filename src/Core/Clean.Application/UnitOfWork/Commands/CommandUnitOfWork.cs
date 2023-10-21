using Clean.Domain.Repositories.Commands;
using Clean.Persistence.Repositories.Commands;

namespace Clean.Application.UnitOfWork.Commands;

public class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public CommandUnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        BasketItem = BasketItem ?? new BasketItemCommand(_context);
        Basket = Basket ?? new BasketCommand(_context);
        Customer = Customer ?? new CustomerCommand(_context);
        Product = Product ?? new ProductCommand(_context);
        Inventory = Inventory ?? new InventoryCommand(_context);
    }


    public IBasketItemCommand BasketItem { get; }
    public IBasketCommand Basket { get; }
    public ICustomerCommand Customer { get; }
    public IProductCommand Product { get; }
    public IInventoryCommand Inventory { get; }
}

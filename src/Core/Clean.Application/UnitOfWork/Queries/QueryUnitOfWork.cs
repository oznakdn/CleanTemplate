using Clean.Domain.Repositories.Queries;
using Clean.Persistence.Repositories.EntityFramework.Queries;

namespace Clean.Application.UnitOfWork.Queries;

public class QueryUnitOfWork : IQueryUnitOfWork
{

    private readonly ApplicationDbContext _context;

    public QueryUnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        BasketItem = BasketItem ?? new BasketItemQuery(_context);
        Basket = Basket ?? new BasketQuery(_context);
        Customer = Customer ?? new CustomerQuery(_context);
        Product = Product ?? new ProductQuery(_context);
        Inventory = Inventory ?? new InventoryQuery(_context);
    }

    public IBasketItemQuery BasketItem { get; }

    public IBasketQuery Basket { get; }

    public ICustomerQuery Customer { get; }

    public IProductQuery Product { get; }

    public IInventoryQuery Inventory { get; }
}

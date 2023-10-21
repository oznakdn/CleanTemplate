using Clean.Domain.Repositories.Queries;
using Clean.Persistence.Repositories.Queries;

namespace Clean.Application.UnitOfWork.Queries;

public class QueryUnitOfWork : IQueryUnitOfWork
{

    private readonly ApplicationDbContext _context;

    public QueryUnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        BasketItem = BasketItem ?? new BasketItemQuery(_context);
        Basket = Basket ?? new BasketQuery(_context);
    }

    public IBasketItemQuery BasketItem { get; }

    public IBasketQuery Basket { get; }
}

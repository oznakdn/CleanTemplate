using Clean.Domain.Baskets;
using Clean.Domain.Repositories;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class BasketItemRepository : EFRepository<BasketItem, ApplicationDbContext, Guid>, IBasketItemRepository
{
    public BasketItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

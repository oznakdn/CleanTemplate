
using Clean.Domain.Baskets;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.Queries;


public class BasketItemQuery : EFQueryRepository<BasketItem, ApplicationDbContext>,IBasketItemQuery
{
    public BasketItemQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

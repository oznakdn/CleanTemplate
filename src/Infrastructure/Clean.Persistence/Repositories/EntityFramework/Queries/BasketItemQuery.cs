using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;


public class BasketItemQuery : EFQueryRepository<BasketItem, ApplicationDbContext>, IBasketItemQuery
{
    public BasketItemQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

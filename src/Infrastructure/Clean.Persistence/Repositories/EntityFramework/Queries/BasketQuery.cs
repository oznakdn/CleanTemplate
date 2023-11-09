using Clean.Domain.Baskets;
using Clean.Domain.Baskets.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class BasketQuery : EFQueryRepository<Basket, ApplicationDbContext>, IBasketQuery
{
    public BasketQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

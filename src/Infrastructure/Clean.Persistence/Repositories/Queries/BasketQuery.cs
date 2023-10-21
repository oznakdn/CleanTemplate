using Clean.Domain.Baskets;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.Queries;

public class BasketQuery : EFQueryRepository<Basket, ApplicationDbContext>, IBasketQuery
{
    public BasketQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

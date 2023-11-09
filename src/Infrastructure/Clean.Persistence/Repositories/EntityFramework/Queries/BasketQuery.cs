using Clean.Domain.Baskets;
using Clean.Domain.Baskets.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class BasketQuery : EFQueryRepository<Basket, EFContext, Guid>, IBasketQuery
{
    public BasketQuery(EFContext context) : base(context)
    {
    }
}

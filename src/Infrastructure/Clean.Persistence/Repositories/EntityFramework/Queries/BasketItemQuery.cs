using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;


public class BasketItemQuery : EFQueryRepository<BasketItem, EFContext, Guid>,IBasketItemQuery
{
    public BasketItemQuery(EFContext context) : base(context)
    {
    }
}

using Clean.Domain.Baskets;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface IBasketItemQuery:IEFQueryAsyncRepository<BasketItem>,IEFQuerySyncRepository<BasketItem>
{
}

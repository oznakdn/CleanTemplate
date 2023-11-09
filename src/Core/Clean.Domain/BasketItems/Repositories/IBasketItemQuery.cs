using Clean.Domain.BasketItems;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.BasketItems.Repositories;

public interface IBasketItemQuery : IEFQueryAsyncRepository<BasketItem>, IEFQuerySyncRepository<BasketItem>
{
}

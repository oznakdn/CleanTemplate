using Clean.Domain.Baskets;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Baskets.Repositories;

public interface IBasketQuery : IEFQueryAsyncRepository<Basket>, IEFQuerySyncRepository<Basket>
{
}

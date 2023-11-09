using Clean.Domain.Inventories;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Inventories.Repositories;

public interface IInventoryQuery :
    IEFQueryAsyncRepository<Inventory>,
    IEFQuerySyncRepository<Inventory>
{
}

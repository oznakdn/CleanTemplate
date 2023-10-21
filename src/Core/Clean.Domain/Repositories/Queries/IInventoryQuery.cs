using Clean.Domain.Products;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface IInventoryQuery : 
    IEFQueryAsyncRepository<Inventory>,
    IEFQuerySyncRepository<Inventory>
{
}

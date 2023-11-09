using Clean.Domain.Inventories;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;
using Gleeman.Repository.EFCore.Interfaces.Command.Delete;
using Gleeman.Repository.EFCore.Interfaces.Command.Update;

namespace Clean.Domain.Inventories.Repositories;

public interface IInventoryCommand :
    IEFCreateAsyncRepository<Inventory>,
    IEFCreateSyncRepository<Inventory>,
    IEFUpdateAsyncRepository<Inventory>,
    IEFUpdateSyncRepository<Inventory>,
    IEFDeleteAsyncRepository<Inventory>,
    IEFDeleteSyncRepository<Inventory>
{
}

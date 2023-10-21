using Clean.Domain.Products;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;
using Gleeman.Repository.EFCore.Interfaces.Command.Delete;
using Gleeman.Repository.EFCore.Interfaces.Command.Update;

namespace Clean.Domain.Repositories.Commands;

public interface IInventoryCommand:
    IEFCreateAsyncRepository<Inventory>,
    IEFCreateSyncRepository<Inventory>,
    IEFUpdateAsyncRepository<Inventory>,
    IEFUpdateSyncRepository<Inventory>,
    IEFDeleteAsyncRepository<Inventory>,
    IEFDeleteSyncRepository<Inventory>
{
}

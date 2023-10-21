using Clean.Domain.Products;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;
using Gleeman.Repository.EFCore.Interfaces.Command.Delete;
using Gleeman.Repository.EFCore.Interfaces.Command.Update;

namespace Clean.Domain.Repositories.Commands;

public interface IProductCommand :
    IEFCreateAsyncRepository<Product>,
    IEFCreateSyncRepository<Product>,
    IEFUpdateAsyncRepository<Product>,
    IEFUpdateSyncRepository<Product>,
    IEFDeleteAsyncRepository<Product>,
    IEFDeleteSyncRepository<Product>
{
}

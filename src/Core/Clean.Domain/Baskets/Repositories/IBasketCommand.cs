using Clean.Domain.Baskets;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;
using Gleeman.Repository.EFCore.Interfaces.Command.Delete;
using Gleeman.Repository.EFCore.Interfaces.Command.Update;

namespace Clean.Domain.Baskets.Repositories;

public interface IBasketCommand : IEFCreateAsyncRepository<Basket>,
    IEFCreateSyncRepository<Basket>,
    IEFUpdateAsyncRepository<Basket>,
    IEFUpdateSyncRepository<Basket>,
    IEFDeleteAsyncRepository<Basket>,
    IEFDeleteSyncRepository<Basket>

{
}

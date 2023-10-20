using Clean.Domain.Baskets;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;
using Gleeman.Repository.EFCore.Interfaces.Command.Delete;
using Gleeman.Repository.EFCore.Interfaces.Command.Update;

namespace Clean.Domain.Repositories.Commands;

public interface IBasketItemCommand:IEFCreateAsyncRepository<BasketItem>,
    IEFCreateSyncRepository<BasketItem>,
    IEFDeleteSyncRepository<BasketItem>,
    IEFUpdateSyncRepository<BasketItem>
{
}

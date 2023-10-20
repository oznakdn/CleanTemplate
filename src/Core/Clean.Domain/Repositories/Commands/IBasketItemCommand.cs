using Clean.Domain.Baskets;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;

namespace Clean.Domain.Repositories.Commands;

public interface IBasketItemCommand:IEFCreateAsyncRepository<BasketItem>,IEFCreateSyncRepository<BasketItem>
{
}

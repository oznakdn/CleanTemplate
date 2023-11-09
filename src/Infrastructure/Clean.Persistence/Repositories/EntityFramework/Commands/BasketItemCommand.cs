using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class BasketItemCommand : EFCommandRepository<BasketItem, EFContext, Guid>, IBasketItemCommand
{
    public BasketItemCommand(EFContext context) : base(context)
    {
    }
}

using Clean.Domain.Baskets;
using Clean.Domain.Baskets.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class BasketCommand : EFCommandRepository<Basket, EFContext, Guid>, IBasketCommand
{
    public BasketCommand(EFContext context) : base(context)
    {
    }
}

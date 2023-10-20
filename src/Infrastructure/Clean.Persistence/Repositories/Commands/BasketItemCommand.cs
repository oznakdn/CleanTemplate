using Clean.Domain.Baskets;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.Commands;

public class BasketItemCommand : EFCommandRepository<BasketItem, ApplicationDbContext>,IBasketItemCommand
{
    public BasketItemCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}

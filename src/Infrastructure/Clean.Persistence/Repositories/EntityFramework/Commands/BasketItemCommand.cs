using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class BasketItemCommand : EFCommandRepository<BasketItem, ApplicationDbContext>, IBasketItemCommand
{
    public BasketItemCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}

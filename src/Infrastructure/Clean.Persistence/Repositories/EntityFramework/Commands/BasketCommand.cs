using Clean.Domain.Baskets;
using Clean.Domain.Baskets.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class BasketCommand : EFCommandRepository<Basket, ApplicationDbContext>, IBasketCommand
{
    public BasketCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

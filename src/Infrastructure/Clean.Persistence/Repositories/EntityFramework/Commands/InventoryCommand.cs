using Clean.Domain.Inventories;
using Clean.Domain.Inventories.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class InventoryCommand : EFCommandRepository<Inventory, ApplicationDbContext>, IInventoryCommand
{
    public InventoryCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

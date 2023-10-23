using Clean.Domain.Products;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class InventoryCommand : EFCommandRepository<Inventory, ApplicationDbContext>, IInventoryCommand
{
    public InventoryCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

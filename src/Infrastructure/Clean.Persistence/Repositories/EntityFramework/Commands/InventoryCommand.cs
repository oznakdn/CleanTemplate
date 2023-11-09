using Clean.Domain.Inventories;
using Clean.Domain.Inventories.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class InventoryCommand : EFCommandRepository<Inventory, EFContext, Guid>, IInventoryCommand
{
    public InventoryCommand(EFContext context) : base(context)
    {
    }
}

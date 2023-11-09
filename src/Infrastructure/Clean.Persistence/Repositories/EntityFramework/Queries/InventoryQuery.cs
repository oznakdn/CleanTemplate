using Clean.Domain.Inventories;
using Clean.Domain.Inventories.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class InventoryQuery : EFQueryRepository<Inventory, EFContext, Guid>, IInventoryQuery
{
    public InventoryQuery(EFContext context) : base(context)
    {
    }
}

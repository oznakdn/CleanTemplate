using Clean.Domain.Inventories;
using Clean.Domain.Inventories.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class InventoryQuery : EFQueryRepository<Inventory, ApplicationDbContext>, IInventoryQuery
{
    public InventoryQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

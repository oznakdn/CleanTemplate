using Clean.Domain.Products;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class InventoryQuery : EFQueryRepository<Inventory, ApplicationDbContext>, IInventoryQuery
{
    public InventoryQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

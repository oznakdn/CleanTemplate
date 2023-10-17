using Clean.Domain.Products;
using Clean.Domain.Repositories;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class InventoryRepository : EFRepository<Inventory, ApplicationDbContext, Guid>, IInventoryRepository
{
    public InventoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

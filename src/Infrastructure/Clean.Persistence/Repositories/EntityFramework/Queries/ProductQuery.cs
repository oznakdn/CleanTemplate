using Clean.Domain.Products;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class ProductQuery : EFQueryRepository<Product, ApplicationDbContext>, IProductQuery
{
    public ProductQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Product>> GetAllProductsWithInventoryAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Products.Include(x => x.Inventory).ToListAsync(cancellationToken);
    
}

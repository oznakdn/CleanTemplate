using Clean.Domain.Products;
using Clean.Domain.Products.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class ProductQuery : EFQueryRepository<Product, ApplicationDbContext>, IProductQuery
{
    public ProductQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Product>> GetAllProductsWithInventoryAsync(int maxPage, int pageSize, int pageNumber, CancellationToken cancellationToken = default)
        => await _dbContext.Products
        .Include(x => x.Inventory)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync(cancellationToken);

}

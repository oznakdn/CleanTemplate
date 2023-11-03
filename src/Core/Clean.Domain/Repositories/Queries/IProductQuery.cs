using Clean.Domain.Products;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface IProductQuery :
    IEFQueryAsyncRepository<Product>,
    IEFQuerySyncRepository<Product>
{
    Task<List<Product>> GetAllProductsWithInventoryAsync(CancellationToken cancellationToken = default(CancellationToken));
}

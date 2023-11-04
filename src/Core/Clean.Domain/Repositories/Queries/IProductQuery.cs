using Clean.Domain.Products;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface IProductQuery :
    IEFQueryAsyncRepository<Product>,
    IEFQuerySyncRepository<Product>
{
    Task<List<Product>> GetAllProductsWithInventoryAsync(int maxPage, int pageSize, int pageNumber, CancellationToken cancellationToken = default(CancellationToken));
}

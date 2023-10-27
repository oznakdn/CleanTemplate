using Clean.Caching.Services;
using Clean.Domain.Products;

namespace Clean.Persistence.Caching;

public interface IProductCacheService:IMemoryCacheService<Product>
{
    IEnumerable<Product> GetProductFromCache();
}

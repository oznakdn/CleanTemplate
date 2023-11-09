using Clean.Caching.Services;
using Clean.Domain.Products;
using Microsoft.Extensions.Caching.Memory;

namespace Clean.Persistence.Caching;

public class ProductCacheService : MemoryCacheService<Product>, IProductCacheService
{
    private readonly EFContext _dbContext;
    public ProductCacheService(IMemoryCache memoryCache, EFContext dbContext) : base(memoryCache)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Product> GetProductFromCache()
    {
        var cacheData = GetDatas("products");
        if (cacheData != null)
        {
            return cacheData;
        }

        cacheData = _dbContext.Products.Include(x => x.Inventory).ToList();
        var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
        SetDatas("products", cacheData, expirationTime);
        return cacheData;
    }
}

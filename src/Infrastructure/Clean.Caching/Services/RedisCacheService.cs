using Microsoft.Extensions.Caching.Distributed;

namespace Clean.Caching.Services;

public abstract class RedisCacheService<T> : IRedisCacheService<T>
{
    protected readonly IDistributedCache distributedCache;

    protected RedisCacheService(IDistributedCache distributedCache)
    {
        this.distributedCache = distributedCache;
    }
}

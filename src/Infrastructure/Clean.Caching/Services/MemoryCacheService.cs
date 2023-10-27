using Microsoft.Extensions.Caching.Memory;

namespace Clean.Caching.Services;

public abstract class MemoryCacheService<T>:IMemoryCacheService<T>
{
    protected readonly IMemoryCache _memoryCache;
    protected MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public T GetData(string key)
    {
        return _memoryCache.Get<T>(key)!;
    }

    public IEnumerable<T> GetDatas(string key)
    {
        return _memoryCache.Get<IEnumerable<T>>(key)!;
    }

    public bool SetData(string key, T data, DateTimeOffset expirationTime)
    {
        if (!string.IsNullOrEmpty(key))
        {
            _memoryCache.Set(key, data, expirationTime);
            return true;
        }
        return false;
    }

    public bool SetDatas(string key, IEnumerable<T> datas, DateTimeOffset expirationTime)
    {
        if (!string.IsNullOrEmpty(key))
        {
            _memoryCache.Set(key, datas, expirationTime);
            return true;
        }
        return false;
    }

    public object RemoveData(string key)
    {
        if (!string.IsNullOrEmpty(key))
        {
            _memoryCache.Remove(key);
            return true;
        }
        return false;
    }

    
}

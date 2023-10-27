using Microsoft.Extensions.Caching.Memory;

namespace Clean.Caching.Services;

public interface IMemoryCacheService<T>
{
    T GetData(string key);
    IEnumerable<T> GetDatas(string key);
    bool SetData (string key, T data, DateTimeOffset expirationTime);
    object RemoveData(string key);
}

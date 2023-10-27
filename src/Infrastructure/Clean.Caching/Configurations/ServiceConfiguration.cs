using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Caching.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddCacheService(this IServiceCollection services, CacheType cacheType, Action<RedisCacheSetting> redisSetting=null)
    {

        switch (cacheType)
        {
            case CacheType.RedisCache:
                RedisCacheSetting redisSettings = new();
                redisSetting?.Invoke(redisSettings);
                services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = redisSettings.ConnectionString;
                option.InstanceName = redisSettings.InstanceName;
            });
                break;
            case CacheType.InMemoryCache:
                services.AddMemoryCache();
                break;
        }
        return services;
    }

    public static IServiceCollection AddCacheService(this IServiceCollection services, CacheType cacheType, IConfiguration configuration)
    {

        services.Configure<RedisCacheSetting>(configuration.GetSection(nameof(RedisCacheSetting)));
        switch (cacheType)
        {
            case CacheType.RedisCache:
                services.AddStackExchangeRedisCache(option =>
                {
                    option.Configuration = configuration.GetValue<string>("RedisSetting:ConnectionString");
                    option.InstanceName = configuration.GetValue<string>("RedisSetting:InstanceName");
                });
                break;
            case CacheType.InMemoryCache:
                services.AddMemoryCache();
                break;
        }

        return services;
    }

}

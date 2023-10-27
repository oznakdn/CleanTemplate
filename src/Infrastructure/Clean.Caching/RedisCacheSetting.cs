namespace Clean.Caching;

public class RedisCacheSetting
{
    public string ConnectionString { get; set; } = string.Empty;
    public string InstanceName { get;set; } = string.Empty;
}

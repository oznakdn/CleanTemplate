namespace Clean.Persistence.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, ProviderType providerType, string connectionString)
    {
        // DbContext configuration
        switch (providerType)
        {
            case ProviderType.MsSQLServer:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
                break;
            case ProviderType.MySQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(ServerVersion.AutoDetect(connectionString)));
                break;
            case ProviderType.PostgreSQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(connectionString));
                break;
            case ProviderType.SQLite:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(connectionString));
                break;
        }

        // Repository configuration

        services.AddScoped<IEFProductRepository, EFProductRepository>();
        services.AddScoped<IEFUserRepository, EFUserRepository>();
        services.AddScoped<IMongoCustomerRepository, MongoCustomerRepository>();

        return services;

    }
}

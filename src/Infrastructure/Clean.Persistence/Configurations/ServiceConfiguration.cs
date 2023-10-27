using Clean.Domain.Repositories.Commands;
using Clean.Domain.Repositories.Queries;
using Clean.Persistence.Repositories.MongoDriver.Commands;
using Clean.Persistence.Repositories.MongoDriver.Queries;
using Gleeman.Repository.MongoDriver.Configuration;
using Microsoft.Extensions.Configuration;
using Clean.Caching.Configurations;
using System.Reflection;
using Clean.Caching;
using Clean.Persistence.Caching;

namespace Clean.Persistence.Configurations;

public static class ServiceConfiguration
{
    public static string ConnectionString;
    public static bool AutoMigration;
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration, ProviderType providerType, Assembly migrationAssembly)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
        ConnectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString")!;
        AutoMigration = configuration.GetValue<bool>("DatabaseSettings:AutoMigration");

        switch (providerType)
        {
            case ProviderType.MsSQLServer:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.MySQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(ServerVersion.AutoDetect(ConnectionString), x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.PostgreSQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.SQLite:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
        }

        services.DependencyInjections();
        services.CacheServiceDependencyInjections();
        services.AddMongoService(configuration);
        services.AddCacheService(CacheType.InMemoryCache, configuration);

        return services;
    }

    private static IServiceCollection DependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<IUserCommand, UserCommand>();
        services.AddScoped<IUserQuery, UserQuery>();
        services.AddScoped<IRoleCommand, RoleCommand>();
        services.AddScoped<IRoleQuery, RoleQuery>();
        return services;
    }

    private static IServiceCollection CacheServiceDependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<IProductCacheService, ProductCacheService>();
        return services;
    }

    private static IServiceCollection AddMongoService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoRepository(configuration);
        return services;
    }

}

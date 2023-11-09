using Clean.Persistence.Repositories.MongoDriver.Commands;
using Clean.Persistence.Repositories.MongoDriver.Queries;
using Microsoft.Extensions.Configuration;
using Clean.Caching.Configurations;
using System.Reflection;
using Clean.Caching;
using Clean.Persistence.Caching;
using Clean.Domain.Users.Repositories;
using Clean.Domain.Roles.Repositories;
using Clean.Persistence.Options.Interfaces;
using Clean.Persistence.Options;

namespace Clean.Persistence.Configurations;

public static class ServiceConfiguration
{
    public static string ConnectionString;
    public static bool AutoMigration;
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration, ProviderType providerType, Assembly migrationAssembly)
    {
        services.Configure<DatabaseOption>(configuration.GetSection(nameof(DatabaseOption)));
        ConnectionString = configuration.GetValue<string>("DatabaseOption:ConnectionString")!;
        AutoMigration = configuration.GetValue<bool>("DatabaseOption:AutoMigration");

        switch (providerType)
        {
            case ProviderType.MsSQLServer:
                services.AddDbContext<EFContext>(option => option.UseSqlServer(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.MySQL:
                services.AddDbContext<EFContext>(option => option.UseMySql(ServerVersion.AutoDetect(ConnectionString), x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.PostgreSQL:
                services.AddDbContext<EFContext>(option => option.UseNpgsql(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.SQLite:
                services.AddDbContext<EFContext>(option => option.UseSqlite(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
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
        services.Configure<MongoOption>(configuration.GetSection(nameof(MongoOption)));
        services.AddScoped<IMongoOption>(opt=> opt.GetRequiredService<IOptions<MongoOption>>().Value);
        return services;
    }

}

using Clean.Domain.Repositories;
using Clean.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using System.Reflection;

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
        return services;
    }

    private static IServiceCollection DependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IBasketItemRepository, BasketItemRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();

        return services;
    }

}

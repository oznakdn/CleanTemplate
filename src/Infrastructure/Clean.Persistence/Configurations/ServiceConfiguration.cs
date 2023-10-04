using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Clean.Persistence.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration, ProviderType providerType, Assembly migrationAssembly)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
        string connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString")!;

        switch (providerType)
        {
            case ProviderType.MsSQLServer:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.MySQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.PostgreSQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(connectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.SQLite:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(connectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
        }

        return services;
    }
}

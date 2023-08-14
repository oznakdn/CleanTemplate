using Clean.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Application.Configurations;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, ProviderType providerType, string connectionString)
    {
        services.AddDbContext<AppDbContext>(option => _ = providerType switch 
        { 
            ProviderType.MSSQLServer  => option.UseSqlServer(connectionString),
            ProviderType.MySQL => option.UseMySql(ServerVersion.AutoDetect(connectionString)),
            ProviderType.PostgreSQL => option.UseNpgsql(connectionString),
            ProviderType.SQLite => option.UseSqlite(connectionString)
        });

        return services;
    }
}

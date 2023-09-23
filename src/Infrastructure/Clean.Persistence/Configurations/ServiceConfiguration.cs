using Microsoft.Extensions.Configuration;

namespace Clean.Persistence.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration, ProviderType providerType)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
        string msSqlConnection = configuration.GetValue<string>("DatabaseSettings:MSSQLServerConnection");
        string mySqlConnection = configuration.GetValue<string>("DatabaseSettings:MySQLConnection");
        string postgreSqlConnection = configuration.GetValue<string>("DatabaseSettings:PostgreSQLConnection");
        string sqLiteConnection = configuration.GetValue<string>("DatabaseSettings:SQLiteConnection");

        switch (providerType)
        {
            case ProviderType.MsSQLServer:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(msSqlConnection));
                break;
            case ProviderType.MySQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(ServerVersion.AutoDetect(mySqlConnection)));
                break;
            case ProviderType.PostgreSQL:
                services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(postgreSqlConnection));
                break;
            case ProviderType.SQLite:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(sqLiteConnection));
                break;
        }

        return services;
    }
}

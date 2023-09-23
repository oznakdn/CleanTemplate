using Microsoft.Extensions.Configuration;

namespace Clean.Persistence.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration, ProviderType providerType)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
        string msSqlConnection = configuration.GetValue<string>("DatabaseOptions:MSSQLServerConnection");
        string mySqlConnection = configuration.GetValue<string>("DatabaseOptions:MySQLConnection");
        string postgreSqlConnection = configuration.GetValue<string>("DatabaseOptions:PostgreSQLConnection");
        string sqLiteConnection = configuration.GetValue<string>("DatabaseOptions:SQLiteConnection");

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

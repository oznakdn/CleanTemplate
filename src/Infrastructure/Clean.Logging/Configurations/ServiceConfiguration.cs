using Gleeman.EffectiveLogger.SQLite.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clean.Logging.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddLoggerService(this IServiceCollection services, IConfiguration configuration,Assembly migrationAssembly)
    {
        services.Configure<LogSettings>(configuration.GetSection(nameof(LogSettings)));
        services.AddSQLiteLog(options =>
        {
            options.WriteToConsole = configuration.GetValue<bool>("LogSettings:WriteToConsole");
            options.WriteToFile = configuration.GetValue<bool>("LogSettings:WriteToFile");
            options.ConnectionString = configuration.GetValue<string>("LogSettings:ConnectionString")!;
            options.FilePath = configuration.GetValue<string>("LogSettings:FilePath")!;
            options.FileName = configuration.GetValue<string>("LogSettings:FileName")!;
            options.MigrationAssembly = migrationAssembly;
        });

        return services;
    }
        

}

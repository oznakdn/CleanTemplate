using Gleeman.EffectiveLogger.Configuration;
using Gleeman.EffectiveLogger.SQLite.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clean.Logging.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddLoggerService(this IServiceCollection services, IConfiguration configuration) => 
        services.AddSQLiteLog(configuration,Assembly.GetExecutingAssembly());

}

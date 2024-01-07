using Gleeman.EffectiveLogger.ConsoleFile.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Logging.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddLoggerService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LogSettings>(configuration.GetSection(nameof(LogSettings)));
        services.AddConsoleFileLog(options =>
        {
            options.WriteToConsole = configuration.GetValue<bool>("LogSettings:WriteToConsole");
            options.WriteToFile = configuration.GetValue<bool>("LogSettings:WriteToFile");
            options.FilePath = configuration.GetValue<string>("LogSettings:FilePath")!;
            options.FileName = configuration.GetValue<string>("LogSettings:FileName")!;
        });

        return services;
    }


}

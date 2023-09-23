using Clean.Application.GlobalException;
using Clean.Persistence;

namespace Clean.Api.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoSettings>(configuration.GetSection(nameof(MongoSettings)));
        services.AddTransient<GlobalExceptionHandler>();

        return services;
    }
}

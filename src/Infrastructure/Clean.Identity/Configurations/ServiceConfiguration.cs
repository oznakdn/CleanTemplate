using Gleeman.JwtGenerator.Configuration;
using Microsoft.Extensions.Configuration;

namespace Clean.Identity.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwtGenerator(configuration);
        return services;
    }
}

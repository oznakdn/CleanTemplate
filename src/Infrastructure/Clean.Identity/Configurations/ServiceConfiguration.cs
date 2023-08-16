namespace Clean.Identity.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        services.AddScoped<IJwtHandler, JwtHandler>();
        return services;
    }
}

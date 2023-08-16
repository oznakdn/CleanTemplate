namespace Clean.Application.Configurations;

public static class ServiceConfiguration
{
    
    public static IServiceCollection AddApplicationService(this IServiceCollection services, ProviderType providerType, string connectionString)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly()); // MediatR configuration
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper configuration
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // FluentValidation configuration
        services.AddPersistenceService(providerType, connectionString); // DbContext  configuration
        services.AddIdentityService(); // Jwt configuration
        return services;
    }

}

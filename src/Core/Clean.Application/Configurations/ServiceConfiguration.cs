using Clean.Domain.Repositories;
using Clean.Notification.Configurations;
using Clean.Persistence.Repositories;

namespace Clean.Application.Configurations;

public static class ServiceConfiguration
{

    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration, ProviderType providerType, Assembly migrationAssembly)
    {
        services.AddAutoMapperService()
                .AddFluentValidationService()
                .AddMediatRService()
                .DependencyInjections();
        services.AddPersistenceService(configuration, providerType, migrationAssembly);
        services.AddIdentityService(configuration);
        services.AddLoggerService(configuration, migrationAssembly);
        services.AddNotificationService(configuration);

        return services;
    }

    private static IServiceCollection AddAutoMapperService(this IServiceCollection service) => service.AddAutoMapper(Assembly.GetExecutingAssembly());
    private static IServiceCollection AddFluentValidationService(this IServiceCollection service) => service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    private static IServiceCollection AddMediatRService(this IServiceCollection service) => service.AddMediatR(Assembly.GetExecutingAssembly());
    private static IServiceCollection DependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IBasketItemRepository, BasketItemRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

}

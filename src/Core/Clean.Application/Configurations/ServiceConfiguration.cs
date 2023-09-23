using Microsoft.Extensions.Configuration;
using Clean.Logging.Configurations;
namespace Clean.Application.Configurations;

public static class ServiceConfiguration
{

    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration, ProviderType providerType)
    {
        services.AddAutoMapperService()
                .AddFluentValidationService()
                .AddMediatRService()
                .AddUnitOfWorkService();
        services.AddPersistenceService(configuration, providerType);
        services.AddIdentityService(configuration);
        services.AddLoggerService(configuration);

        return services;
    }

    private static IServiceCollection AddAutoMapperService(this IServiceCollection service) => service.AddAutoMapper(Assembly.GetExecutingAssembly());
    private static IServiceCollection AddFluentValidationService(this IServiceCollection service) => service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    private static IServiceCollection AddMediatRService(this IServiceCollection service) => service.AddMediatR(Assembly.GetExecutingAssembly());
    private static IServiceCollection AddUnitOfWorkService(this IServiceCollection services)
    {
        services.AddScoped<IEfUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IMongoUnitOfWork, MongoUnitOfWork>();
        return services;
    }

}

﻿using Clean.Application.DataShaping;
using Clean.Application.Features.Baskets.Commands.AddBasketItem;
using Clean.Application.Features.Baskets.Commands.DeleteBasketItem;
using Clean.Application.Features.Baskets.Commands.UpdateBasket;
using Clean.Application.Features.Customers.Commands.Create;
using Clean.Application.Features.Orders.Commands.Create;
using Clean.Application.Features.Products.Commands.Create;
using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Notification.Configurations;
using Clean.Logging.Configurations;
using Mapster;

namespace Clean.Application.Configurations;

public static class ServiceConfiguration
{

    public static IServiceCollection AddApplicationService(this IServiceCollection services,
        IConfiguration configuration,
        ProviderType providerType,
        Assembly migrationAssembly)
    {
        services.AddAutoMapperService()
                .AddFluentValidationService()
                .AddMediatRService()
                .DependencyInjections();
        services.AddPersistenceService(configuration, providerType, migrationAssembly);
        services.AddIdentityService(configuration);
        services.AddLoggerService(configuration);
        services.AddNotificationService(configuration);
        services.AddMapSterService();

        return services;
    }

    private static IServiceCollection AddAutoMapperService(this IServiceCollection service) => service.AddAutoMapper(Assembly.GetExecutingAssembly());

    private static void AddMapSterService(this IServiceCollection services) => services.AddMapster();
    private static IServiceCollection AddFluentValidationService(this IServiceCollection service) => service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    private static IServiceCollection AddMediatRService(this IServiceCollection service) => service.AddMediatR(Assembly.GetExecutingAssembly());

    private static IServiceCollection DependencyInjections(this IServiceCollection services)
    {
        services.AddScoped(typeof(CreateBasketEventHandler));
        services.AddScoped(typeof(AddBasketItemEventHandler));
        services.AddScoped(typeof(AddInventoryEventHandler));
        services.AddScoped(typeof(UpdateInventoryEventHandler));
        services.AddScoped(typeof(DeleteBasketItemEventHandler));
        services.AddScoped(typeof(UpdateBasketItemEventHandler));
        services.AddScoped(typeof(UpdateCustomerEventHandler));
        services.AddScoped(typeof(DeletedBasketItemsEventHandler));
        services.AddScoped(typeof(CreateOrderItemEventHandler));

        services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();
        services.AddScoped<IQueryUnitOfWork,QueryUnitOfWork>();
        services.AddScoped(typeof(IDataShaper<>), typeof(DataShaper<>));
        return services;
    }

}



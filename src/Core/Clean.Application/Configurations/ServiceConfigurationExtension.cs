using Clean.Identity.Jwt.Handler;
using Clean.Persistence.Contexts;
using Clean.Persistence.Contexts.Enums;
using Clean.Persistence.Repositories;
using Clean.Persistence.Repositories.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clean.Application.Configurations;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddContextService(this IServiceCollection services, ContextType contextType, string connectionString)
    {

        switch (contextType)
        {
            case ContextType.MsSQLContext:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
                break;
            case ContextType.MySQLContext:
                services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(ServerVersion.AutoDetect(connectionString)));
                break;
            case ContextType.PostgreSQLContext:
                services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(connectionString));
                break;
            case ContextType.SQLiteContext:
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(connectionString));
                break;
        }

        return services;
    }

    public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }

    public static IServiceCollection AddMediatRService(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }

    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtHandler,JwtHandler>();
        return services;
    }

    public static IServiceCollection AddFleuntValidationService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }

}

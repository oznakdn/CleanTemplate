using Microsoft.AspNetCore.RateLimiting;

namespace Clean.Api.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApiService(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandler>();
        services.AddSwaggerService();

        return services;
    }

    private static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
        });

        services.AddRateLimiterService();

        return services;
    }

    private static IServiceCollection AddRateLimiterService(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter("Api", options =>
            {
                options.AutoReplenishment = true;
                options.PermitLimit = 10;
                options.Window = TimeSpan.FromMinutes(1);
            });

            options.AddFixedWindowLimiter("Web", options =>
            {
                options.AutoReplenishment = true;
                options.PermitLimit = 20;
                options.Window = TimeSpan.FromMinutes(1);
            });

        });

        return services;
    }

}

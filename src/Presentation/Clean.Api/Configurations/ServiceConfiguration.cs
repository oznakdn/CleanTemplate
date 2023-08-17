using Clean.Application.GlobalException;

namespace Clean.Api.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));
        services.Configure<MongoSetting>(configuration.GetSection("MongoSetting"));

        // Authentication configuration with JWT
        services.AddAuthentication(scheme => scheme.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(option =>
       {
           option.SaveToken = true;
           option.TokenValidationParameters = new()
           {
               ValidateIssuer = configuration.GetValue<bool>("JwtSetting:ValidateIssuer"),
               ValidateAudience = configuration.GetValue<bool>("JwtSetting:ValidateAudience"),
               ValidateIssuerSigningKey = configuration.GetValue<bool>("JwtSetting:ValidateIssuerSigningKey"),
               ValidateLifetime = configuration.GetValue<bool>("JwtSetting:ValidateLifetime"),
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtSetting:SecurityKey"))),
               ValidIssuer = configuration.GetValue<string>("JwtSetting:Issuer"),
               ValidAudience = configuration.GetValue<string>("JwtSetting:Audience"),
               ClockSkew = TimeSpan.Zero
           };
       });

        // Application configuration
        services.AddApplicationService(providerType: ProviderType.SQLite, configuration["ConnectionStrings:SQLite"]);

        // Middleware configuration
        services.AddTransient<GlobalExceptionHandler>();

        return services;
    }
}

using Clean.Notification.NotificationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Notification.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddNotificationService(this IServiceCollection services,IConfiguration configuration)
    {
       services.Configure<NotificationSettings>(configuration.GetSection(nameof(NotificationSettings)));
       services.AddTransient<IMailService, MailService>();
        return services;
    }
}

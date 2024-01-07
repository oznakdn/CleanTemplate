using Clean.WebRazorPages.Filters;
using Clean.WebRazorPages.Services;
using Microsoft.Extensions.Options;

namespace Clean.WebRazorPages;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorPages();
        builder.Services.Configure<EndPoints>(builder.Configuration.GetSection(nameof(EndPoints)));
        builder.Services.AddScoped(sp => sp.GetRequiredService<IOptions<EndPoints>>().Value);
        builder.Services.AddSession();
        builder.Services.AddHttpClient("CleanClient", conf => conf.BaseAddress = new Uri(builder.Configuration["BaseUrl"]!));
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddScoped<AuthorizationFilter>();
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<ProductService>();


        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();
        app.UseSession();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}

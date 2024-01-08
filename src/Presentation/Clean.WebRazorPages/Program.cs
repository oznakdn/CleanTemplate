using Clean.WebRazorPages;
using Clean.WebRazorPages.Filters;
using Clean.WebRazorPages.Pages.Admin.Auth;
using Clean.WebRazorPages.Pages.Product;
using Microsoft.Extensions.Options;

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

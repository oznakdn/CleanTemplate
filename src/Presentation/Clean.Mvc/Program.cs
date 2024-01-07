using Clean.Mvc.ClientServices;
using Clean.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("CleanClient", conf =>
{
    conf.BaseAddress = new Uri("http://localhost:5019/api/"); 
});

builder.Services.AddSession();
//builder.Services.AddScoped<AuthorizationFilter>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthService>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin", 
    areaName: "Admin", 
    pattern: "Admin/{controller=Auth}/{action=Login}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

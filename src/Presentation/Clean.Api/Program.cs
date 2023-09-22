using Clean.Application.GlobalException;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Services.AddApiService(builder.Configuration);
string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:SQLite");
builder.Services.AddApplicationService(builder.Configuration, providerType: ProviderType.SQLite, connectionString);



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandler>();
app.MapControllers();

app.Run();

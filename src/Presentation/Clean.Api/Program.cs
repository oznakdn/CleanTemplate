var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiService(builder.Configuration);
builder.Services.AddApplicationService(builder.Configuration, providerType: ProviderType.PostgreSQL, Assembly.GetExecutingAssembly());
builder.Services.AddHealthChecks();


var app = builder.Build();
app.MapHealthChecks("/healtCheck");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWTAuthDemo v1"));
}

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandler>();
app.MapControllers();

app.Run();

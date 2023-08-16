
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddContextService(ContextType.SQLiteContext, builder.Configuration["ConnectionStrings:SQLite"]);
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JwtSetting"));
builder.Services.Configure<MongoSetting>(builder.Configuration.GetSection("MongoSetting"));
builder.Services.AddAuthentication(scheme => scheme.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.SaveToken = true;
        option.TokenValidationParameters = new()
        {
            ValidateIssuer = builder.Configuration.GetValue<bool>("JwtSetting:ValidateIssuer"),
            ValidateAudience = builder.Configuration.GetValue<bool>("JwtSetting:ValidateAudience"),
            ValidateIssuerSigningKey = builder.Configuration.GetValue<bool>("JwtSetting:ValidateIssuerSigningKey"),
            ValidateLifetime = builder.Configuration.GetValue<bool>("JwtSetting:ValidateLifetime"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSetting:SecurityKey"))),
            ValidIssuer = builder.Configuration.GetValue<string>("JwtSetting:Issuer"),
            ValidAudience = builder.Configuration.GetValue<string>("JwtSetting:Audience"),
            ClockSkew = TimeSpan.Zero
        };

    });

builder.Services.AddAutoMapperService();
builder.Services.AddMediatRService();
builder.Services.AddApplicationService();
builder.Services.AddFleuntValidationService();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

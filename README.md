# Clean Template 

<p>
    This repo was created to be an example of clean architecture and to be easily integrated into our future projects. 
</p>

```bash

    CleanTemplate
    |
    ├── src
    |   ├── Core
    │   |    ├── Clean.Application
    │   |    ├── Clean.Domain.Contracts
    |   |    └── Clean.Domain
    │   ├── Infrastructure
    |   |    ├── Clean.Caching
    |   |    ├── Clean.Identity
    |   |    ├── Clean.Logging
    |   |    ├── Clean.Notification
    |   |    └── Clean.Persistence
    |   └── Presentation
    |        ├── Clean.Api
    |        └── Clean.Mvc
    └── test
        ├── UnitTests
        └── IntegrationTests
```

## Features

- [x] Clean Architecture
- [X] Domain driven design (DDD)
- [x] CQRS
- [x] Asp .Net Core Web Api
- [x] Asp .Net Core Mvc
- [x] Entity Framework Core 7
- [x] MongoDriver
- [x] Sqlite, SqlServer, PostgreSQL, MySql, MongoDB
- [x] Generic repository pattern
- [x] Unit Of Work pattern
- [X] Pagination and Filtering
- [x] Claim based authentication with Json Web Token
- [x] Password hashing
- [x] Logging
- [X] Redis and InMemoryCache
- [X] HealthCheck
- [X] Rate Limiting
- [x] MapSter
- [x] FluentValidation
- [X] Email and Notification Service
- [ ] SignalR 
- [ ] Unit tests
- [ ] Integration tests

## Migration Commands
#### Terminal
```csharp
$ cd CleanTemplate/src/Infrastructure/Clean.Persistence
```
```csharp
$ dotnet ef migrations add [MigrationName] --context [ContextName] --startup-project [ProjectDirectoryPath]
```
```csharp
$ dotnet ef database update --context [ContextName] --startup-project [ProjectDirectoryPath]
```


## Packages
```csharp
Gleeman.EffectiveLogger
Gleeman.EffectiveLogger.SQLite
Gleeman.JwtGenerator
Gleeman.Repository.EFCore
Gleeman.Repository.MongoDriver
BCrypt.Net-Next
MongoDB.Driver
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.SqlServer
Npgsql.EntityFrameworkCore.PostgreSQL
Pomelo.EntityFrameworkCore.MySql
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Proxies
AutoMapper.Extensions.Microsoft.DependencyInjection
FluentValidation.DependencyInjectionExtensions
MediatR.Extensions.Microsoft.DependencyInjection
MailKit
```

## Rate Limiting
### Program.cs
```csharp
builder.Services.AddRateLimiter(options =>
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
```
```csharp
app.UseRateLimiter();
```
### Controller
```csharp
public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [EnableRateLimiting("Api")]
    public async Task<IActionResult>GetProducts()
    {
        var result = await _mediator.Send(new GetProductsRequest());
        return Ok(result.Datas);
    }
}

```
<hr>

## Health Check
### Program.cs
```csharp
//http://localhost:5019/healtCheck
app.MapHealthChecks("/healtCheck");
```


# Clean Template 

<p>
    The Clean Template Project is an open source project written in .NETCore.<br>
    The goal of this project is to apply widely used technologies and share them with communities. <br>
    If you like the project please give it a star :star:
</p>

```bash

    CleanTemplate
    |
    ├── src
    |   ├── Core
    │   |    ├── Clean.Application
    │   |    ├── Clean.Domain
    │   |    ├── Clean.Domain.Contracts
    |   |    └── Clean.Domain.Shared
    │   ├── Infrastructure
    |   |    ├── Clean.Caching
    |   |    ├── Clean.Identity
    |   |    ├── Clean.Logging
    |   |    ├── Clean.Notification
    |   |    └── Clean.Persistence
    |   └── Presentation
    |        ├── Clean.Api
    |        ├── Clean.Mvc
    |        └── Clean.WebRazorPages
    └── test
        └── UnitTests
```

## Features

- [x] Clean Architecture
- [X] Domain driven design (DDD) <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/DomainDrivenDesign.md">View</a>
- [X] Custom Domain Events
- [x] CQRS
- [x] Entity Framework Core 7 <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/EFCore.md">View</a>
- [x] MongoDriver
- [x] Sqlite, SqlServer, PostgreSQL, MySql, MongoDB
- [x] Generic repository pattern <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/GenericRepository.md">View</a>
- [x] Unit Of Work pattern <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/UnitOfWork.md">View</a>
- [x] Result pattern
- [X] Pagination, Filtering and Sorting
- [X] Data Shaping <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/DataShaping.md">View</a>
- [x] Claim based authentication with Json Web Token
- [x] Password Hashing
- [x] Logging
- [X] Redis and InMemory Caching
- [X] Health Check <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/HealthCheck.md">View</a>
- [X] Rate Limiting <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/RateLimiting.md">View</a>
- [x] MapSter
- [x] FluentValidation
- [x] MediatR
- [X] Email and Notification Service
- [X] Unit tests
- [x] Asp .Net Core Web Api <a href="https://github.com/oznakdn/CleanTemplate/tree/master/src/Presentation/Clean.Api">View</a>
- [x] Asp .Net Core Mvc <a href="https://github.com/oznakdn/CleanTemplate/tree/master/src/Presentation/Clean.Mvc">View</a>
- [x] Asp .Net Core WebApp(Razor Pages) <a href="https://github.com/oznakdn/CleanTemplate/tree/master/src/Presentation/Clean.WebRazorPages">View</a>



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
MediatR.Extensions.Microsoft.DependencyInjection
FluentValidation.DependencyInjectionExtensions
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Proxies
Npgsql.EntityFrameworkCore.PostgreSQL
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql
Gleeman.EffectiveLogger.SQLite
Gleeman.EffectiveLogger
Gleeman.JwtGenerator
BCrypt.Net-Next
MongoDB.Driver
Mapster
MailKit
```
## Api Endpoints
![endpoints](https://github.com/oznakdn/CleanTemplate/assets/79724084/249dc317-c0a6-446a-a8a1-5a271e192a33)


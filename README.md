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
- [X] Domain driven design (DDD) <a href="https://github.com/oznakdn/CleanTemplate/blob/master/docs/DomainDrivenDesign.md">View</a>
- [X] Custom Domain Events
- [x] CQRS
- [x] Asp .Net Core Web Api
- [x] Asp .Net Core Mvc
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
Mapster
FluentValidation.DependencyInjectionExtensions
MediatR.Extensions.Microsoft.DependencyInjection
MailKit
```


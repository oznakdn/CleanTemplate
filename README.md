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
- [X] Domain driven design (DDD)
- [X] Custom Domain Events
- [x] CQRS
- [x] Asp .Net Core Web Api
- [x] Asp .Net Core Mvc
- [x] Entity Framework Core 7
- [x] MongoDriver
- [x] Sqlite, SqlServer, PostgreSQL, MySql, MongoDB
- [x] Generic repository pattern
- [x] Unit Of Work pattern
- [x] Result pattern
- [X] Pagination, Filtering and Sorting
- [x] Claim based authentication with Json Web Token
- [x] Password hashing
- [x] Logging
- [X] Redis and InMemoryCache
- [X] HealthCheck
- [X] Rate Limiting
- [x] MapSter
- [x] FluentValidation
- [x] MediatR
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
Mapster
FluentValidation.DependencyInjectionExtensions
MediatR.Extensions.Microsoft.DependencyInjection
MailKit
```


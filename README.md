# Clean Template 

<p>
    This repo was created to be an example of clean architecture and to be easily integrated into our future projects. 
    If you want to contribute to the project, fork the project and submit a pull request.
</p>

```bash

    CleanTemplate
    |
    ├── src
    |   ├── Core
    │   |    ├── Clean.Application
    │   |    └── Clean.Domain
    │   ├── Infrastructure
    |   |    ├── Clean.Identity
    |   |    ├── Clean.Logging
    |   |    ├── Clean.Notification
    |   |    └── Clean.Persistence
    |   └── Presentation
    |        ├── Clean.Api
    |        └── Clean.WebUI
    └── test
        ├── UnitTests
        └── IntegrationTests
```

## Features

- [x] Asp .Net Core 7
- [x] Entity Framework Core 7
- [x] Sqlite, SqlServer, PostgreSQL, MySql
- [x] Mongo Driver 
- [x] SQL and NoSQL databases
- [x] Generic repository pattern
- [x] Unit Of Work pattern
- [ ] Domain driven design (DDD)
- [x] CQRS
- [x] Claim based authentication with Json Web Token
- [x] Password hashing
- [x] Logging
- [ ] Caching with Redis,Memcache and InMemoryCache
- [x] Object mapping
- [x] Validation
- [X] Notification Service
- [ ] Unit tests
- [ ] Integration tests




## Packages
```csharp
Gleeman.EffectiveLogger.SQLite
Gleeman.JwtGenerator
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

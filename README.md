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
    │   |    ├── Clean.Domain.Contracts
    |   |    └── Clean.Domain
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
- [ ] Pagination and Filtering
- [x] Unit Of Work pattern
- [ ] Domain driven design (DDD)
- [x] CQRS
- [x] Claim based authentication with Json Web Token
- [x] Password hashing
- [x] Logging
- [ ] Caching with Redis,Memcache and InMemoryCache
- [x] Object mapping
- [x] Validations
- [X] Notification Service
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

## If you'd like to use this template in your projects!
#### 1- In Microsoft Visual Studio, Solution Explorer, right-click the project you want to rename and click Rename.
#### 2- In the In-place text editor, enter a new name
![GUID-7E331960-6D23-43B4-B175-F7DD0DD312E0](https://github.com/oznakdn/CleanTemplate/assets/79724084/485e1ed0-0d0e-4b44-b29d-749a2ef730d1)


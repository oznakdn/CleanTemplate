# Clean Template 

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
- [x] CQRS - Mediator pattern
- [x] Claim based authentication with Json Web Token
- [x] Password hashing
- [x] Logging
- [x] Caching with Redis,Memcache and InMemoryCache
- [x] Object mapping
- [x] Validation
- [ ] Notification Service


## DOMAIN

### Base entities

```csharp
/* SQL */
public interface IEntity<TId>:IEquatable<IEntity<TId>>
{
    TId Id { get; set; }
}
public abstract class Entity<TId> : IEntity<TId>
{
    public virtual TId Id { get; set; }
}

/* NoSQL */

public interface IMongoEntity
{
    string Id { get; set; }
}

public abstract class MongoEntity : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement]
    public string Id { get; set; }
}
```
### Base identities

```csharp

/* SQL */
public class UserIdentity<TId> : Entity<TId>
{
    public virtual string? FirstName { get; set; }
    public virtual string? LastName { get; set; }
    public virtual string? Username { get; set; }
    public virtual string Email { get; set; }
    public virtual string PasswordHash { get; set; }
}

public class RoleIdentity<TId> : Entity<TId>
{
    public string RoleTitle { get; set; }
    public string Description { get; set; }
}

/* NoSQL */

public abstract class MongoUserIdentity:MongoEntity
{
    [BsonElement]
    public string? FirstName { get; set; }

    [BsonElement]
    public string? LastName { get; set; }

    [BsonElement]
    public string? Username { get; set; }

    [BsonElement]
    public string Email { get; set; }

    [BsonElement]
    public string PasswordHash { get; set; }
}

public abstract class MongoRoleIdentity:MongoEntity
{
    [BsonElement]
    public string RoleTitle { get; set; }

    [BsonElement]
    public string Description { get; set; }
}

```
## APPLICATION


### Use to db context

```csharp
public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options){}

    public DbSet<Product> Products { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<AppRole> Roles { get; set; }
    //  You can write own tables
}

```

### Db context registration ioc container

    ├── Clean.Api                   
    ├── Configurations                                
    └── ServiceConfiguration 
    
```csharp
builder.Services.AddApplicationService(builder.Configuration, providerType: ProviderType.SQLite);
```

### Migration commands

```csharp
> C:\CleanTemplate\src\Infrastructure\Clean.Persistence
```
```csharp
> dotnet ef migrations add InitDb --context ApplicationDbContext --startup-project C:\Users\HP\Desktop\Ozan\CleanTemplate\src\Presentation\Clean.Api
```
```csharp
> dotnet ef database update --context ApplicationDbContext --startup-project C:\Users\HP\Desktop\Ozan\CleanTemplate\src\Presentation\Clean.Api
```

### appsetting.json

```csharp
{
  "AllowedHosts": "*",
  "TokenSetting": {
    "SaveToken": true,
    "ValidateIssuer": true,
    "ValidateAudience": true,
    "ValidateLifetime": true,
    "Issuer": "http://localhost:5019",
    "Audience": "http://localhost:27250",
    "SigningKey": "729e13bb78b745e9bf82c4245fc4eaca"
  },
  "DatabaseOptions": {
    "MSSQLServerConnection": "",
    "MySQLConnection": "",
    "PostgreSQLConnection": "",
    "SQLiteConnection": "Data Source = C:/Users/HP/Desktop/Ozan/CleanTemplate/src/Infrastructure/Clean.Persistence/ExampleDB.db"
  },
  "MongoSettings": {
    "Connection": "mongodb://localhost:27017",
    "Database": "MongoExampleDB"
  },
  "LogOptions": {
    "WriteToFile": true,
    "WriteToDatabase": true,
    "FilePath": "C:\\Users\\HP\\Desktop\\Ozan\\CleanTemplate\\src\\Presentation\\Clean.Api\\FileLog",
    "FileName": "Api",
    "DatabaseOptions": {
      "SQLiteConnectionString": "Data Source = C:\\Users\\HP\\Desktop\\Ozan\\CleanTemplate\\src\\Presentation\\Clean.Api\\DataLog\\LogDb.db",
      "MSSqlServerConectionString": "",
      "PostgreSqlConnectionString": "",
      "MySqlConnectionString": ""
    },
    "NotificationSettings": {
      "DisplayName": "",
      "From": "",
      "UserName": "",
      "Password": "",
      "Host": "",
      "Port": "",
      "UseSSL": false,
      "UseStartTls": true
    }
}
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

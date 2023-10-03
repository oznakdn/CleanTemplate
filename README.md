# Clean Template 

### Features

- [x] Asp .Net Core 7
- [x] Entity Framework Core 7
- [x] Mongo Driver 
- [x] SQL and NoSQL databases
- [x] Generic repository pattern
- [x] Unit Of Work pattern
- [x] CQRS - Mediator pattern
- [x] Claim based authentication with Json Web Token
- [x] Password hashing
- [x] Logging
- [x] Caching with Redis
- [x] Object mapping
- [x] Validation
- [ ] Notification Service

## HOW TO USE? 


### Creating new entities and identites for ef or mongo

#### Base entities

    ├── Clean.Domain                   
    ├── Entities
    ├── SQL-NoSQL
    └── Abstracts

```csharp
/* Entity Framework */
public class Entity<TKey> : IEntity<TKey>
{
    public virtual TKey Id { get; set; }
}

/* Mongo Driver */
public abstract class MongoEntity : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement]
    public string Id { get; set; }
}

```
#### Entities

    ├── Clean.Domain                   
    ├── Entities
    └── SQL-NoSQL
    
```csharp
/* Entity Framework models */

public class Product : Entity<Guid>
{
   // you can write here your properties
}

public class AppUser:UserIdentity<Guid>
{
   // you can write here your properties 
}

public class AppRole:RoleIdentity<Guid>
{
   // you can write here your properties
}

/* Mongo models */

public class Customer: MongoEntity
{
   // you can write here your properties
}

```
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

# Clean Template 

### Features

- [x] Asp .Net Core 7
- [x] Entity Framework Core 7
- [x] Mongo Driver 
- [x] SQL and NoSQL databases
- [x] Generic repository pattern 
- [x] CQRS - MediatR pattern
- [x] Role based authentication with Json Web Token
- [x] Logging with NLog
- [x] Caching with Redis
- [x] AutoMapper
- [x] FluentValidation
- [ ] Mail Service

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
services.AddApplicationService(providerType: ProviderType.SQLite, configuration["ConnectionStrings:SQLite"]);
```

### Migration commands

<p>PowerShell cd C:\CleanTemplate\src\Infrastructure\Clean.Persistence</p>
<p>dotnet ef migrations add InitDb --startup-project C:\CleanTemplate\src\Presentation\Clean.Api</p>
<p></p>dotnet ef database update --startup-project C:\CleanTemplate\src\Presentation\Clean.Api<p>

  
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
    }
  }
}
```


Current Packages

[![Nuget version](https://img.shields.io/nuget/v/blazored.localstorage.svg?logo=nuget)](https://www.nuget.org/packages/Blazored.LocalStorage/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Blazored.LocalStorage?logo=nuget)](https://www.nuget.org/packages/Blazored.LocalStorage/)
![Build & Test Main](https://github.com/Blazored/LocalStorage/workflows/Build%20&%20Test%20Main/badge.svg)

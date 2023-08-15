<h1>Clean Template</h1> 
<h2>Everything a dotnet project should have...</h2><hr>
<h3>Features</h3>

- [x] Generic repository pattern implementation
- [x] CQRS - MediatR pattern implementation
- [x] Role based authentication with Json Web Token
- [x] SQL or NoSQL databases
- [x] Logging with NLog
- [x] Caching with Redis
- [x] AutoMapper
- [x] FluentValidation
- [ ] Mail Service
- [ ] Message queue with RabbitMQ




# $\textcolor{red}{\textsf{HOW TO USE}}$ 

#### $\textcolor{green}{\textsf{appsetting.json}}$ 
```
"JwtSetting": {
  "ValidateIssuer": true, // true or false
  "ValidateAudience": true, // true or false
  "ValidateIssuerSigningKey": true, // true or false
  "ValidateLifetime": true, // true or false
  "Issuer": "", // write your issuer
  "Audience": "", // write your audience
  "SecurityKey": "" // write your key
},
"ConnectionStrings": {
  "MSSQLServer": "", // Example ===> Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
  "MySQL": "", // Example ===> Host=myServerAddress;UserName=myUsername;Password=myPassword;Database=myDataBase;
  "PostgreSQL": "", // Example ===> Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;
  "SQLite": "" // Example ===> Data Source=c:\mydb.db;
},
"MongoSettings": {
  "Connection": "",
  "Database": "",
  "Collection": ""
}
```
#### $\textcolor{green}{\textsf{To Create new entities and identites}}$ 

```
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

```
#### $\textcolor{green}{\textsf{Use to db context}}$

```
public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options){}

    public DbSet<Product> Products { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<AppRole> Roles { get; set; }
    //  You can write own tables
}

```


Current Packages

[![Nuget version](https://img.shields.io/nuget/v/blazored.localstorage.svg?logo=nuget)](https://www.nuget.org/packages/Blazored.LocalStorage/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Blazored.LocalStorage?logo=nuget)](https://www.nuget.org/packages/Blazored.LocalStorage/)
![Build & Test Main](https://github.com/Blazored/LocalStorage/workflows/Build%20&%20Test%20Main/badge.svg)

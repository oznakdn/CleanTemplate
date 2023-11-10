# Entity Framework Core


## Option

```csharp
public class DatabaseOption
{
    public string ConnectionString { get; set; } = string.Empty;
}
```
## DbContext
```csharp
public class EFContext:DbContext
{
    public EFContext(DbContextOptions<EFContext>options):base(options)
    {
        if(!string.IsNullOrEmpty(ServiceConfiguration.ConnectionString) && ServiceConfiguration.AutoMigration == true)
        {
            Database.EnsureCreated();
        }
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory>Inventories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderItemConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketItemConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketConfiguration).Assembly);
    }

}
```


## Service Registration
```csharp
public static class ServiceConfiguration
{
    public static string ConnectionString;
    public static bool AutoMigration;
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration, ProviderType providerType, Assembly migrationAssembly)
    {
        services.Configure<DatabaseOption>(configuration.GetSection(nameof(DatabaseOption)));
        ConnectionString = configuration.GetValue<string>("DatabaseOption:ConnectionString")!;
        AutoMigration = configuration.GetValue<bool>("DatabaseOption:AutoMigration");

        switch (providerType)
        {
            case ProviderType.MsSQLServer:
                services.AddDbContext<EFContext>(option => option.UseSqlServer(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.MySQL:
                services.AddDbContext<EFContext>(option => option.UseMySql(ServerVersion.AutoDetect(ConnectionString), x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.PostgreSQL:
                services.AddDbContext<EFContext>(option => option.UseNpgsql(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
            case ProviderType.SQLite:
                services.AddDbContext<EFContext>(option => option.UseSqlite(ConnectionString, x => x.MigrationsAssembly(migrationAssembly.FullName)));
                break;
        }
        return services;
    }

}

```

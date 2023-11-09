using Clean.Domain.BasketItems;
using Clean.Domain.Baskets;
using Clean.Domain.Customers;
using Clean.Domain.Inventories;
using Clean.Domain.OrderItems;
using Clean.Domain.Orders;
using Clean.Domain.Products;
using Clean.Persistence.Configurations;
using Clean.Persistence.EntityConfigurations;

namespace Clean.Persistence.Contexts;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
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

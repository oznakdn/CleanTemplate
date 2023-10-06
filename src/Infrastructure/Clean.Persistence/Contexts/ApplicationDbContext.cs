using Clean.Domain.Entities.Category;
using Clean.Domain.Entities.Product;
using Clean.Domain.Identities.Role;
using Clean.Domain.Identities.User;
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
    public DbSet<Category>Categories { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<AppRole> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);

    }
}

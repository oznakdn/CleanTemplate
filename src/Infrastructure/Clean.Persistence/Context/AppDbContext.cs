using Clean.Domain.Entities;
using Clean.Domain.Identities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<AppUser>Users { get; set; }
    public DbSet<AppRole> Roles { get; set; }
}

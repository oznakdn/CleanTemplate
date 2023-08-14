using Clean.Domain.Entities;
using Clean.Domain.Identities;
using Clean.Persistence.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Contexts;

public class SQLiteContext : DbContext
{
    public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<AppRole> Roles { get; set; }
}

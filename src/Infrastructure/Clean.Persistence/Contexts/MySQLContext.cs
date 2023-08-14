using Clean.Persistence.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Contexts;

public class MySQLContext : DbContext, IDbContext
{
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
    {
    }
}

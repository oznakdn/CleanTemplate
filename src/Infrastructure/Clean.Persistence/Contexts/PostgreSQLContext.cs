using Clean.Persistence.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Contexts;

public class PostgreSQLContext : DbContext, IDbContext
{
    public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
    {
    }
}

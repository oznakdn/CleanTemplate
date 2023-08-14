using Clean.Persistence.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Contexts;

public class MsSQLContext : DbContext, IDbContext
{
    public MsSQLContext(DbContextOptions<MsSQLContext> options) : base(options)
    {
    }
}

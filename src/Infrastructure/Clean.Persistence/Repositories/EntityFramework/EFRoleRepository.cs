using Clean.Persistence.Repositories.EntityFramework.Interfaces;

namespace Clean.Persistence.Repositories.EntityFramework;

public class EFRoleRepository : EFRepository<AppRole, ApplicationDbContext, Guid>, IEFRoleRepository
{
    public EFRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

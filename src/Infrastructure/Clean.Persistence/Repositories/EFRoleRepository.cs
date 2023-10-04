using Clean.Domain.Identities.Role;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class EFRoleRepository : EFRepository<AppRole, ApplicationDbContext, Guid>, IEFRoleRepository
{
    public EFRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

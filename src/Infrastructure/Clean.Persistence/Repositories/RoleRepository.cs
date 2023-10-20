using Clean.Domain.Account;
using Clean.Domain.Repositories;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class RoleRepository : MongoRepository<Role>, IRoleRepository
{
    public RoleRepository(IOptions<MongoSettings> setting) : base(setting,nameof(Role))
    {
    }
}

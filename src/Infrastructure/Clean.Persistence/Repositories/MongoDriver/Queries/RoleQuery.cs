using Clean.Domain.Roles;
using Clean.Domain.Roles.Repositories;
using Clean.Persistence.Options.Interfaces;
using Clean.Persistence.Repositories.MongoDriver.Common;

namespace Clean.Persistence.Repositories.MongoDriver.Queries;

public class RoleQuery : MongoQueryRepository<Role>, IRoleQuery
{
    public RoleQuery(IMongoOption option) : base(option, nameof(Role))
    {
    }
}

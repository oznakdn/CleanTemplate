using Clean.Domain.Roles;
using Clean.Domain.Roles.Repositories;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Query;

namespace Clean.Persistence.Repositories.MongoDriver.Queries;

public class RoleQuery : MongoQueryRepository<Role>, IRoleQuery
{
    public RoleQuery(IOptions<MongoOption>? option) : base(option, nameof(Role))
    {
    }
}

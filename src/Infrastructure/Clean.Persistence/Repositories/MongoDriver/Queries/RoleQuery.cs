using Clean.Domain.Account;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Query;

namespace Clean.Persistence.Repositories.MongoDriver.Queries;

public class RoleQuery : MongoQueryRepository<Role>, IRoleQuery
{
    public RoleQuery(IOptions<MongoOption>? option) : base(option, nameof(Role))
    {
    }
}

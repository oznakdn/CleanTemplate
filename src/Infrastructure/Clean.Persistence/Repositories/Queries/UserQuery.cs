using Clean.Domain.Account;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Query;

namespace Clean.Persistence.Repositories.Queries;

public class UserQuery : MongoQueryRepository<User>, IUserQuery
{
    public UserQuery(IOptions<MongoOption>? option) : base(option, nameof(User))
    {
    }
}

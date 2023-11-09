using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using Clean.Persistence.Options.Interfaces;
using Clean.Persistence.Repositories.MongoDriver.Common;

namespace Clean.Persistence.Repositories.MongoDriver.Queries;

public class UserQuery : MongoQueryRepository<User>, IUserQuery
{
    public UserQuery(IMongoOption option) : base(option,nameof(User))
    {
    }
}

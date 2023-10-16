using Clean.Domain.Repositories;
using Clean.Domain.Users;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class UserRepository : MongoRepository<User>,IUserRepository
{
    public UserRepository(IOptions<MongoSettings> setting, string collectionName) : base(setting, collectionName)
    {
    }
}

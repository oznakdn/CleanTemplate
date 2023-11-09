using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using Clean.Persistence.Options.Interfaces;
using Clean.Persistence.Repositories.MongoDriver.Common;

namespace Clean.Persistence.Repositories.MongoDriver.Commands;

public class UserCommand : MongoCommandRepository<User>, IUserCommand
{
    public UserCommand(IMongoOption option) : base(option,nameof(User))
    {
    }
}

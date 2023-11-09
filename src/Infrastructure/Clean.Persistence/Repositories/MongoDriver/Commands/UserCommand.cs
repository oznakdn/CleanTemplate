using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Command;

namespace Clean.Persistence.Repositories.MongoDriver.Commands;

public class UserCommand : MongoCommandRepository<User>, IUserCommand
{
    public UserCommand(IOptions<MongoOption>? option) : base(option, nameof(User))
    {
    }
}

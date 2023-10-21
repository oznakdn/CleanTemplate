using Clean.Domain.Account;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Command;

namespace Clean.Persistence.Repositories.Commands;

public class RoleCommand : MongoCommandRepository<Role>, IRoleCommand
{
    public RoleCommand(IOptions<MongoOption>? option) : base(option, nameof(Role))
    {
    }
}

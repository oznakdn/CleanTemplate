using Clean.Domain.Roles;
using Clean.Domain.Roles.Repositories;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Command;

namespace Clean.Persistence.Repositories.MongoDriver.Commands;

public class RoleCommand : MongoCommandRepository<Role>, IRoleCommand
{
    public RoleCommand(IOptions<MongoOption>? option) : base(option, nameof(Role))
    {
    }
}

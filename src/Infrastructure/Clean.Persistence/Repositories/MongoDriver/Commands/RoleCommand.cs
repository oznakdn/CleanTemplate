using Clean.Domain.Roles;
using Clean.Domain.Roles.Repositories;
using Clean.Persistence.Options.Interfaces;
using Clean.Persistence.Repositories.MongoDriver.Common;

namespace Clean.Persistence.Repositories.MongoDriver.Commands;

public class RoleCommand : MongoCommandRepository<Role>, IRoleCommand
{
    public RoleCommand(IMongoOption option) : base(option,nameof(Role))
    {
    }
}

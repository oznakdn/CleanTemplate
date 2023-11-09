using Clean.Domain.Roles;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Create;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Update;

namespace Clean.Domain.Roles.Repositories;

public interface IRoleCommand : IMongoCreateAsyncRepository<Role>, IMongoUpdateAsyncRepository<Role>
{
}

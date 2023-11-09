using Clean.Domain.Roles;
using Gleeman.Repository.MongoDriver.Interfaces.Query;

namespace Clean.Domain.Roles.Repositories;

public interface IRoleQuery : IMongoQueryAsyncRepository<Role>
{
}

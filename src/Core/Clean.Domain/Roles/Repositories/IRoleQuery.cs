using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Roles.Repositories;

public interface IRoleQuery : IMongoQueryRepository<Role>
{
}

using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Roles.Repositories;

public interface IRoleCommand : IMongoCommandRepository<Role>
{
}

using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Users.Repositories;

public interface IUserQuery : IMongoQueryRepository<User>
{
}

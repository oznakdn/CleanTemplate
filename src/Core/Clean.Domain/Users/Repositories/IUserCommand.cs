using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Users.Repositories;

public interface IUserCommand : IMongoCommandRepository<User>
{
}

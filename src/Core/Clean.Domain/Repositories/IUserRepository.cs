using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Users;

namespace Clean.Domain.Repositories;

public interface IUserRepository : IMongoRepositroy<User>
{
}

using Clean.Domain.Users;
using Gleeman.Repository.MongoDriver.Interfaces.Query;

namespace Clean.Domain.Users.Repositories;

public interface IUserQuery : IMongoQueryAsyncRepository<User>
{
}

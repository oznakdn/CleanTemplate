using Clean.Domain.Account;
using Gleeman.Repository.MongoDriver.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface IUserQuery:IMongoQueryAsyncRepository<User>
{
}

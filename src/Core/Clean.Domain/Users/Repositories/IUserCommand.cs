using Clean.Domain.Users;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Create;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Update;

namespace Clean.Domain.Users.Repositories;

public interface IUserCommand :
    IMongoCreateAsyncRepository<User>,
    IMongoUpdateAsyncRepository<User>
{
}

﻿using Clean.Domain.Account;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Create;
using Gleeman.Repository.MongoDriver.Interfaces.Command.Update;

namespace Clean.Domain.Repositories.Commands;

public interface IRoleCommand:IMongoCreateAsyncRepository<Role>,IMongoUpdateAsyncRepository<Role>
{
}

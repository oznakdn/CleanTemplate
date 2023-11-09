﻿using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using Gleeman.Repository.MongoDriver;
using Gleeman.Repository.MongoDriver.Abstracts.Query;

namespace Clean.Persistence.Repositories.MongoDriver.Queries;

public class UserQuery : MongoQueryRepository<User>, IUserQuery
{
    public UserQuery(IOptions<MongoOption>? option) : base(option, nameof(User))
    {
    }
}

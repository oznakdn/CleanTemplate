﻿using Clean.Domain.Account;
using Clean.Domain.Repositories;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class UserRepository : MongoRepository<User>,IUserRepository
{
    public UserRepository(IOptions<MongoSettings> setting) : base(setting, nameof(User))
    {
    }
}

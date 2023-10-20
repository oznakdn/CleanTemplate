﻿using Clean.Domain.Account;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Repositories;

public interface IUserRepository : IMongoRepositroy<User>
{
}

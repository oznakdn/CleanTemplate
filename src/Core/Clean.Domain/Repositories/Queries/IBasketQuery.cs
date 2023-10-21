﻿using Clean.Domain.Baskets;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface IBasketQuery:IEFQueryAsyncRepository<Basket>,IEFQuerySyncRepository<Basket>
{
}
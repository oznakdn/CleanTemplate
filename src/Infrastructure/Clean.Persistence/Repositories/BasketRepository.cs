﻿using Clean.Domain.Baskets;
using Clean.Domain.Repositories;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class BasketRepository : EFRepository<Basket, ApplicationDbContext, Guid>, IBasketRepository
{
    public BasketRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
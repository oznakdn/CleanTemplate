﻿using Clean.Domain.Baskets;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.Commands;

public class BasketCommand : EFCommandRepository<Basket, ApplicationDbContext>, IBasketCommand
{
    public BasketCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

﻿using Clean.Domain.Orders;
using Clean.Domain.Orders.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class OrderQuery : EFQueryRepository<Order, ApplicationDbContext>, IOrderQuery
{
    public OrderQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

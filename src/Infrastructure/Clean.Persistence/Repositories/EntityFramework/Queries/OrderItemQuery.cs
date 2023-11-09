using Clean.Domain.OrderItems;
using Clean.Domain.OrderItems.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class OrderItemQuery : EFQueryRepository<OrderItem, ApplicationDbContext>, IOrderItemQuery
{
    public OrderItemQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

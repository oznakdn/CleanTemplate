using Clean.Domain.Orders;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class OrderItemQuery : EFQueryRepository<OrderItem, ApplicationDbContext>, IOrderItemQuery
{
    public OrderItemQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

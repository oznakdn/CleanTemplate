using Clean.Domain.OrderItems;
using Clean.Domain.OrderItems.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class OrderItemQuery : EFQueryRepository<OrderItem, EFContext, Guid>, IOrderItemQuery
{
    public OrderItemQuery(EFContext context) : base(context)
    {
    }
}

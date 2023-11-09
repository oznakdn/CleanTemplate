using Clean.Domain.Orders;
using Clean.Domain.Orders.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class OrderQuery : EFQueryRepository<Order, EFContext, Guid>, IOrderQuery
{
    public OrderQuery(EFContext context) : base(context)
    {
    }
}

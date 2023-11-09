using Clean.Domain.Orders;
using Clean.Domain.Orders.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class OrderCommand : EFCommandRepository<Order, EFContext, Guid>, IOrderCommand
{
    public OrderCommand(EFContext context) : base(context)
    {
    }
}

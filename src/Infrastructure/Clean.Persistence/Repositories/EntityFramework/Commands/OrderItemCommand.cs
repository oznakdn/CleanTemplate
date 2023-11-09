using Clean.Domain.OrderItems;
using Clean.Domain.OrderItems.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class OrderItemCommand : EFCommandRepository<OrderItem, EFContext, Guid>, IOrderItemCommand
{
    public OrderItemCommand(EFContext context) : base(context)
    {
    }
}

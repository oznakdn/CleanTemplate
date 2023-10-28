using Clean.Domain.Orders;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class OrderItemCommand : EFCommandRepository<OrderItem, ApplicationDbContext>, IOrderItemCommand
{
    public OrderItemCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

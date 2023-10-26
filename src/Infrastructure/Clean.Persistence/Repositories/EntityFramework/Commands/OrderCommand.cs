using Clean.Domain.Orders;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class OrderCommand : EFCommandRepository<Order, ApplicationDbContext>, IOrderCommand
{
    public OrderCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

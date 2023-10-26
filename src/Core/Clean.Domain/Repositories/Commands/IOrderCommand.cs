using Clean.Domain.Orders;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;

namespace Clean.Domain.Repositories.Commands;

public interface IOrderCommand:IEFCreateAsyncRepository<Order>
{
}

using Clean.Domain.Orders;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;

namespace Clean.Domain.Orders.Repositories;

public interface IOrderCommand : IEFCreateAsyncRepository<Order>
{
}

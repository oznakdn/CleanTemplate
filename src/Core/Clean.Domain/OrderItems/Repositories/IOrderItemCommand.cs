using Clean.Domain.OrderItems;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;

namespace Clean.Domain.OrderItems.Repositories;

public interface IOrderItemCommand : IEFCreateAsyncRepository<OrderItem>, IEFCreateSyncRepository<OrderItem>
{
}

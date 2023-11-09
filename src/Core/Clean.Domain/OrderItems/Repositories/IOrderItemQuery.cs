using Clean.Domain.OrderItems;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.OrderItems.Repositories;

public interface IOrderItemQuery : IEFQueryAsyncRepository<OrderItem>
{
}

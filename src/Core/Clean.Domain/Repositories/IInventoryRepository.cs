using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Products;

namespace Clean.Domain.Repositories;

public interface IInventoryRepository : IEFRepository<Inventory,Guid>
{
}

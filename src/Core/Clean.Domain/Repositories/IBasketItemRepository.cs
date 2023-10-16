using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Repositories;

public interface IBasketItemRepository : IEFRepository<BasketItem,Guid>
{
}

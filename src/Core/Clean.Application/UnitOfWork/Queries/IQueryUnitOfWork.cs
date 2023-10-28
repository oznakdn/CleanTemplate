using Clean.Domain.Repositories.Queries;

namespace Clean.Application.UnitOfWork.Queries;

public interface IQueryUnitOfWork
{
    IBasketItemQuery BasketItem { get; }
    IBasketQuery Basket { get; }
    ICustomerQuery Customer { get; }
    IProductQuery Product { get; }
    IInventoryQuery Inventory { get; }
    IOrderQuery Order { get; }
}

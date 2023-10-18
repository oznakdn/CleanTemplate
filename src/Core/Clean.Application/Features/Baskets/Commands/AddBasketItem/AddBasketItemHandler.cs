using Clean.Application.Results;
using Clean.Domain.Baskets;
using Clean.Domain.Products;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Commands.AddBasketItem;

public record AddBasketItemRequest(string BasketId, string ProductId, int Quantity) : IRequest<IDataResult<AddBasketItemResponse>>;
public record AddBasketItemResponse;

public class AddBasketItemHandler : IRequestHandler<AddBasketItemRequest, IDataResult<AddBasketItemResponse>>
{
    private readonly IBasketRepository _basket;
    private readonly IProductRepository _product;
    private readonly AddBasketItemEventHandler _addBasketItemEvent;
    private readonly UpdateInventoryEventHandler _updateInventoryEvent;

    public AddBasketItemHandler(IBasketRepository basket, AddBasketItemEventHandler addBasketItemEvent, IProductRepository product, UpdateInventoryEventHandler updateInventoryEvent)
    {
        _basket = basket;
        _product = product;
        _addBasketItemEvent = addBasketItemEvent;
        _updateInventoryEvent = updateInventoryEvent;
    }

    public async Task<IDataResult<AddBasketItemResponse>> Handle(AddBasketItemRequest request, CancellationToken cancellationToken)
    {
        new DataResult<AddBasketItemResponse>();

        var basket = await _basket.GetAsync(cancellationToken, x => x.Id == Guid.Parse(request.BasketId));
        if (basket is null)
        {
           return new DataResult<AddBasketItemResponse>("Basket not found",false);
        }

        var product = await _product.GetAsync(cancellationToken, x => x.Id == Guid.Parse(request.ProductId));
        if (product is null)
        {
           return new DataResult<AddBasketItemResponse>("Product not found",false);

        }

        // Updated inventory
        Inventory inventory = await _updateInventoryEvent.Publish(new UpdateInventoryEvent(product.Id,request.Quantity), cancellationToken);

        // Adding basketItem
        BasketItem basketItem = await _addBasketItemEvent.Publish(new AddBasketItemEvent(basket, product, request.Quantity), cancellationToken);
        basket.AddBasketItem(basketItem);

        // Saving in database
        _basket.Update(basket);
        await _basket.SaveAsync(cancellationToken);

        return new DataResult<AddBasketItemResponse>("Item added in the basket", true);
    }
}

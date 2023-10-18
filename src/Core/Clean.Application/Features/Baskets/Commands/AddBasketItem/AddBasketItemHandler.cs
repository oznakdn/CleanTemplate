using Clean.Application.Results;
using Clean.Domain.Baskets;
using Clean.Domain.Products;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Commands.AddBasketItem;

public record AddBasketItemRequest(string BasketId, string ProductId, int Quantity) : IRequest<AddBasketItemResponse>;
public class AddBasketItemResponse : Response { }

public class AddBasketItemHandler : IRequestHandler<AddBasketItemRequest, AddBasketItemResponse>
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

    public async Task<AddBasketItemResponse> Handle(AddBasketItemRequest request, CancellationToken cancellationToken)
    {
        AddBasketItemResponse response = new();
        var basket = await _basket.GetAsync(cancellationToken, x => x.Id == Guid.Parse(request.BasketId));
        if (basket is null)
        {
            response.Successed = false;
            response.Message = "Basket not found!";
            return response;
        }

        var product = await _product.GetAsync(cancellationToken, x => x.Id == Guid.Parse(request.ProductId));
        if (product is null)
        {
            response.Successed = false;
            response.Message = "Product not found!";
            return response;
        }


        // Updated inventory
        Inventory inventory = await _updateInventoryEvent.Publish(new UpdateInventoryEvent(product.Id,request.Quantity), cancellationToken);

        // Adding basketItem
        BasketItem basketItem = await _addBasketItemEvent.Publish(new AddBasketItemEvent(basket, product, request.Quantity), cancellationToken);
        basket.AddBasketItem(basketItem);

        // Saving in database
        _basket.Update(basket);
        await _basket.SaveAsync(cancellationToken);
        response.Successed = true;
        response.Message = "Item was added.";
        return response;
    }
}

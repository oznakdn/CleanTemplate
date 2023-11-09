using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Events;
using Clean.Domain.Inventories;
using Clean.Domain.Shared;

namespace Clean.Application.Features.Baskets.Commands.AddBasketItem;

public record AddBasketItemRequest(string BasketId, string ProductId, int Quantity) : IRequest<TResult<AddBasketItemResponse>>;
public record AddBasketItemResponse;

public class AddBasketItemHandler : IRequestHandler<AddBasketItemRequest, TResult<AddBasketItemResponse>>
{
    private readonly ICommandUnitOfWork _command;
    private readonly IQueryUnitOfWork _query;
    private readonly AddBasketItemEventHandler _addBasketItemEvent;
    private readonly UpdateInventoryEventHandler _updateInventoryEvent;

    public AddBasketItemHandler(
        ICommandUnitOfWork command, 
        IQueryUnitOfWork query, 
        AddBasketItemEventHandler addBasketItemEvent, 
        UpdateInventoryEventHandler updateInventoryEvent)
    {
        _command = command;
        _query = query;
        _addBasketItemEvent = addBasketItemEvent;
        _updateInventoryEvent = updateInventoryEvent;
    }

    public async Task<TResult<AddBasketItemResponse>> Handle(AddBasketItemRequest request, CancellationToken cancellationToken)
    {
        
        var basket = await _query.Basket.ReadSingleOrDefaultAsync(true,x => x.Id == Guid.Parse(request.BasketId),cancellationToken);
        if (basket is null)
        {
            return TResult<AddBasketItemResponse>.Fail("Basket not found!");
            
        }

        var product = await _query.Product.ReadSingleOrDefaultAsync(true, x => x.Id == Guid.Parse(request.ProductId), cancellationToken);
        if (product is null)
        {
           return TResult<AddBasketItemResponse>.Fail("Product not found");

        }

        // Updated inventory
        Inventory inventory =await _updateInventoryEvent.PublishAsync(new UpdateInventoryEvent(product.Id,request.Quantity),cancellationToken);

        // Adding basketItem
        BasketItem basketItem =await _addBasketItemEvent.PublishAsync(new AddBasketItemEvent(basket, product, request.Quantity), cancellationToken);
        basket.AddBasketItem(basketItem);

        // Saving in database
        _command.Basket.Edit(basket);
        await _command.Basket.ExecuteAsync(cancellationToken);

        return  TResult<AddBasketItemResponse>.Ok("Item added in the basket");
    }
}

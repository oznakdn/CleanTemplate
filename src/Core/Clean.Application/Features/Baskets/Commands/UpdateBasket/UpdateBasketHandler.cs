﻿using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.BasketItems;
using Clean.Domain.BasketItems.Events;
using Clean.Shared;


namespace Clean.Application.Features.Baskets.Commands.UpdateBasket;

public record UpdateBasketRequest(string BasketId, string BasketItemId, int Quantity) : IRequest<IResult<UpdateBasketResponse>>;
public record UpdateBasketResponse;

public class UpdateBasketHandler : IRequestHandler<UpdateBasketRequest, IResult<UpdateBasketResponse>>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;
    private readonly UpdateBasketItemEventHandler _updateBasketItemEvent;

    public UpdateBasketHandler(IQueryUnitOfWork query, ICommandUnitOfWork command, UpdateBasketItemEventHandler updateBasketItemEvent)
    {
        _query = query;
        _command = command;
        _updateBasketItemEvent = updateBasketItemEvent;
    }

    public async Task<IResult<UpdateBasketResponse>> Handle(UpdateBasketRequest request, CancellationToken cancellationToken)
    {
        var basket = await _query.Basket.ReadSingleOrDefaultAsync(true, x => x.Id == Guid.Parse(request.BasketId), cancellationToken);

        if (basket is null)
            return Result<UpdateBasketResponse>.Fail("Basket not found!");


        BasketItem basketItem = await _updateBasketItemEvent.PublishAsync(new UpdateBasketItemEvent(
            Guid.Parse(request.BasketItemId),
            request.Quantity
            ), cancellationToken);

        basket.UpdateBasketItemQuantity(basketItem.ProductPrice, request.Quantity);

        _command.Basket.Edit(basket);
        await _command.Basket.ExecuteAsync(cancellationToken);
        return Result<UpdateBasketResponse>.Success($"Item was updated to {request.Quantity}");
    }
}

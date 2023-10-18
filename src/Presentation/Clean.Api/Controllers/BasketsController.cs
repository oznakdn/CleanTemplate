﻿using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Baskets.Commands.AddBasketItem;
using Clean.Application.Features.Baskets.Commands.DeleteBasketItem;
using Clean.Application.Features.Baskets.Queries.GetCustomerBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;


public class BasketsController : AbstractController
{
    public BasketsController(IMediator mediator) : base(mediator)
    {

    }


    [HttpGet("{CustomerId}")]
    public async Task<IActionResult>GetCustomerBasket(string CustomerId)
    {
        var result = await _mediator.Send(new GetCustomerBasketRequest(CustomerId));
        if(result.Successed)
            return Ok(result);
        return NotFound(result.Message);
    }


    [HttpPost]
    public async Task<IActionResult> AddBasketItem([FromBody] AddBasketItemRequest addBasketItem)
    {
        var result = await _mediator.Send(addBasketItem);
        if(result.IsSuccessed)
            return Ok(result.Message);
        return NotFound(result.Message);
    }

    [HttpPut]
    public async Task<IActionResult> RemoveBasketItem([FromQuery] string BasketId, [FromQuery] string BasketItemId)
    {
        var result = await _mediator.Send(new DeleteBasketItemRequest(BasketId, BasketItemId));
        if(result.IsSuccessed) return Ok(result.Message);
        return NotFound(result.Message);
    }
}

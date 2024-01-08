using Clean.Application.Features.Baskets.Commands.AddBasketItem;
using Clean.Application.Features.Baskets.Commands.DeleteBasketItem;
using Clean.Application.Features.Baskets.Commands.UpdateBasket;

namespace Clean.Api.Controllers;


public class BasketsController : AbstractController
{
    public BasketsController(IMediator mediator) : base(mediator)
    {

    }

    [HttpPost]
    public async Task<IActionResult> AddBasketItem([FromBody] AddBasketItemRequest addBasketItem)
    {
        var result = await _mediator.Send(addBasketItem);
        if(result.IsSuccess)
            return Ok(result.Message);
        return NotFound(result.Message);
    }

    [HttpPut]
    public async Task<IActionResult> RemoveBasketItem([FromQuery] string BasketId, [FromQuery] string BasketItemId)
    {
        var result = await _mediator.Send(new DeleteBasketItemRequest(BasketId, BasketItemId));
        if(result.IsSuccess) return Ok(result.Message);
        return NotFound(result.Message);
    }

    [HttpPut("{quantity}")]
    public async Task<IActionResult> UpdateBasketItem([FromQuery] string BasketId, [FromQuery] string BasketItemId,int quantity)
    {
        var result = await _mediator.Send(new UpdateBasketRequest(BasketId, BasketItemId,quantity));
        if (result.IsSuccess) return Ok(result.Message);
        return NotFound(result.Message);
    }
}

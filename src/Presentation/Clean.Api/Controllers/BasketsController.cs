using Clean.Application.Features.Baskets.Commands.AddBasketItem;
using Clean.Application.Features.Baskets.Commands.DeleteBasketItem;
using Clean.Application.Features.Baskets.Commands.UpdateBasket;

namespace Clean.Api.Controllers;

[Route("api/baskets")]
public class BasketsController : AbstractController
{
    public BasketsController(IMediator mediator) : base(mediator)
    {

    }

    [HttpPost("add-basket-item")]
    public async Task<IActionResult> AddBasketItem([FromBody] AddBasketItemRequest addBasketItem)
    {
        var result = await _mediator.Send(addBasketItem);
        if(result.IsSuccess)
            return Ok(result.Message);
        return NotFound(result.Message);
    }

    [HttpPut("remove-basket-item")]
    public async Task<IActionResult> RemoveBasketItem([FromQuery] string BasketId, [FromQuery] string BasketItemId)
    {
        var result = await _mediator.Send(new DeleteBasketItemRequest(BasketId, BasketItemId));
        if(result.IsSuccess) return Ok(result.Message);
        return NotFound(result.Message);
    }

    [HttpPut("update-basket-item/{quantity}")]
    public async Task<IActionResult> UpdateBasketItem([FromQuery] string BasketId, [FromQuery] string BasketItemId,int quantity)
    {
        var result = await _mediator.Send(new UpdateBasketRequest(BasketId, BasketItemId,quantity));
        if (result.IsSuccess) return Ok(result.Message);
        return NotFound(result.Message);
    }
}

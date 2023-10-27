using Clean.Application.Features.Orders.Commands.Create;

namespace Clean.Api.Controllers;


public class OrdersController : AbstractController
{
    public OrdersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromQuery] string customerId)
    {
        var result = await _mediator.Send(new CreateOrderRequest(customerId));
        if (result.IsSuccessed)
        {
            return Created("", result.Message);
        }

        return BadRequest(result.Message);
    }
}

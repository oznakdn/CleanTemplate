using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Abstract;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class AbstractController : ControllerBase
{
    protected readonly IMediator _mediator;

    public AbstractController(IMediator mediator)
    {
        _mediator = mediator;
    }
}

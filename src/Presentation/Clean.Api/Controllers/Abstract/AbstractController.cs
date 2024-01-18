namespace Clean.Api.Controllers.Abstract;


[ApiController]
public abstract class AbstractController : ControllerBase
{
    protected readonly IMediator _mediator;

    public AbstractController(IMediator mediator)
    {
        _mediator = mediator;
    }
}

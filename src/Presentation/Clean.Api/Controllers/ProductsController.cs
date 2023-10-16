using Clean.Api.Controllers.Abstract;
using MediatR;

namespace Clean.Api.Controllers;

//[Authorize]
public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    
}

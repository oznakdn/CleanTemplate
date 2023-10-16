using Clean.Api.Controllers.Abstract;
using MediatR;

namespace Clean.Api.Controllers;


public class CustomersController : AbstractController
{
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

   
}
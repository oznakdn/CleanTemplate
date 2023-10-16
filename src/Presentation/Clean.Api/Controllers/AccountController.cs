using Clean.Api.Controllers.Abstract;
using MediatR;

namespace Clean.Api.Controllers
{
    public class AccountController : AbstractController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }


       
    }
}

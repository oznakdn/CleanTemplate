using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Queries.UserQueries.Login.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : AbstractController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginRequest loginRequest)
        {
            var result = await _mediator.Send(loginRequest);
            if(result.ErrorMessages!=null)
            {
                return BadRequest(result.ErrorMessages);
            }

            return Ok(result);
        }
    }
}

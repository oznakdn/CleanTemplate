using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Commands.UserCommands.Register.Dtos;
using Clean.Application.Features.Queries.UserQueries.Login.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    public class AccountController : AbstractController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost("/login")]
        public async Task<IActionResult>Login(LoginRequest loginRequest)
        {
            var result = await _mediator.Send(loginRequest);
            if(result.ErrorMessages!=null)
            {
                return BadRequest(result.ErrorMessages);
            }

            return Ok(result);
        }


        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var result = await _mediator.Send(registerRequest);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Message);
        }
    }
}

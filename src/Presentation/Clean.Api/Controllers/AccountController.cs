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


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _mediator.Send(loginRequest);
            if (result.Success)
            {
                return Ok(new { Token = result.Token, Expire = result.TokenExpiredDate });
            }
            else if (!result.Success && !string.IsNullOrEmpty(result.Message))
            {
                return NotFound(result.Message);
            }
            return BadRequest(result.Errors);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var result = await _mediator.Send(registerRequest);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            if (result.Errors != null && !result.Success)
            {
                return BadRequest(result.Errors);
            }

            return BadRequest(result.Message);
        }
    }
}

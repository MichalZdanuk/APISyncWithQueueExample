using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemA.Application.Commands.Users.CreateUser;
using SystemA.Application.DTOs;

namespace SystemA.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCustomer([FromBody] CreateUserDto dto)
        {
            var command = new CreateUserCommand(dto.UserName, dto.Email, dto.DateOfBirth);

            await _mediator.Send(command);

            var uri = $"api/users/{command.Id}";

            return Created(uri, new { Id = command.Id });
        }

    }
}

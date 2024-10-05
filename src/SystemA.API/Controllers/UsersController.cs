using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemA.Application.Commands.Users.CreateUser;
using SystemA.Application.DTOs.Users;
using SystemA.Application.Queries.Users.BrowseUsers;
using SystemA.Application.Queries.Users.GetUser;

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
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var command = new CreateUserCommand(dto.UserName, dto.Email, dto.DateOfBirth);

            await _mediator.Send(command);

            var uri = $"api/users/{command.Id}";

            return Created(uri, new { Id = command.Id });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser([FromRoute]Guid id)
        {
            var query = new GetUserQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<UserDto>>> BrowseUsers()
        {
            var query = new BrowseUsersQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}

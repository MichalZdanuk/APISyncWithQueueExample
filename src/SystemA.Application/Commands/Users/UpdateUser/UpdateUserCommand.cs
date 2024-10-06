using MediatR;

namespace SystemA.Application.Commands.Users.UpdateUser
{
    public record UpdateUserCommand(Guid Id, string UserName, string Email, DateTime DateOfBirth) : IRequest;
}

using MediatR;

namespace SystemA.Application.Commands.Users.CreateUser
{
    public record CreateUserCommand(string UserName, string Email, DateTime DateOfBirth) : IRequest
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}

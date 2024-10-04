using MediatR;
using SystemA.Application.Repositories;
using SystemA.Domain.Entities;

namespace SystemA.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = PrepareUserFromCommand(command);

            userRepository.Add(user);

            await userRepository.SaveChangesAsync();
        }

        private User PrepareUserFromCommand(CreateUserCommand command)
            => User.Create(command.Id, command.UserName, command.Email, command.DateOfBirth);
    }
}

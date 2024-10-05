using MediatR;
using SystemA.Application.Events;
using SystemA.Application.Queues;
using SystemA.Application.Repositories;
using SystemA.Domain.Entities;

namespace SystemA.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository,
        IMessagePublisher messagePublisher) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = PrepareUserFromCommand(command);

            userRepository.Add(user);

            await userRepository.SaveChangesAsync();

            var userCreatedEvent = new UserCreatedEvent(user.Id, user.UserName, user.Email, user.DateOfBirth);
            await messagePublisher.PublishAsync(userCreatedEvent, "UserCreate");
        }

        private User PrepareUserFromCommand(CreateUserCommand command)
            => User.Create(command.Id, command.UserName, command.Email, command.DateOfBirth);
    }
}

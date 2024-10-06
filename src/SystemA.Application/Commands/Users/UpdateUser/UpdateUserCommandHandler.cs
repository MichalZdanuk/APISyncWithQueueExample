using MediatR;
using SystemA.Application.Queues;
using SystemA.Application.Repositories;
using SystemA.Contracts.Events.Users;
using SystemA.Domain.Entities;
using SystemA.Domain.Exceptions.Users;

namespace SystemA.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler(IUserRepository userRepository,
        IMessagePublisher messagePublisher)
        : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(command.Id);

            if (user is null)
            {
                throw new UserNotFoundException(command.Id);
            }

            UpdateUser(user, command);
            await userRepository.SaveChangesAsync();

            var userUpdatedEvent = new UserUpdatedEvent(user.Id, user.UserName, user.Email, user.DateOfBirth);

            await messagePublisher.PublishAsync(userUpdatedEvent, "UserUpdate");
        }

        private void UpdateUser(User user, UpdateUserCommand command)
        {
            user.UserName = command.UserName;
            user.Email = command.Email;
            user.DateOfBirth = command.DateOfBirth;
        }
    }
}

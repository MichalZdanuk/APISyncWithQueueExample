using SystemA.Contracts.Events.Users;

namespace SystemB.Application.Events.External.Users
{
    public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
    {
        public Task Handle(UserCreatedEvent @event)
        {
            Console.WriteLine($"User Created Event Received: {@event.UserName}, {@event.Email}, {@event.DateOfBirth}");

            return Task.CompletedTask;
        }
    }
}

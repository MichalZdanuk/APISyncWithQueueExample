using SystemA.Contracts.Events.Users;

namespace SystemB.Application.Events.External.Users
{
    public class UserUpdatedEventHandler : IEventHandler<UserUpdatedEvent>
    {
        public Task Handle(UserUpdatedEvent @event)
        {
            Console.WriteLine($"User Updated Event Received: {@event.UserName}, {@event.Email}, {@event.DateOfBirth}");
            return Task.CompletedTask;
        }
    }
}

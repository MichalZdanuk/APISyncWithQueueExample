using Shared.Queues;

namespace SystemA.Contracts.Events.Users
{
    public class UserCreatedEvent : IMessage
    {
        private UserCreatedEvent() { }

        public Guid MessageId { get; }
        public Guid UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        public DateTime DateOfBirth { get; }

        public UserCreatedEvent(Guid userId, string userName, string email, DateTime dateOfBirth)
        {
            MessageId = Guid.NewGuid();
            UserId = userId;
            UserName = userName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}

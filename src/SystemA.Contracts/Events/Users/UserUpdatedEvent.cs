using Shared.Queues;

namespace SystemA.Contracts.Events.Users
{
    public class UserUpdatedEvent : IMessage
    {
        private UserUpdatedEvent() { }


        public Guid MessageId { get; }
        public Guid Id { get; }
        public string UserName { get; }
        public string Email { get; }
        public DateTime DateOfBirth { get; }

        public UserUpdatedEvent(Guid id, string userName, string email, DateTime dateOfBirth)
        {
            MessageId = Guid.NewGuid();
            Id = id;
            UserName = userName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}

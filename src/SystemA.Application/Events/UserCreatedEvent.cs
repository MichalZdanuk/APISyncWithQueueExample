using SystemA.Application.Queues;

namespace SystemA.Application.Events
{
    public class UserCreatedEvent : IMessage
    {
        private UserCreatedEvent() { }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public UserCreatedEvent(Guid id, string userName, string email, DateTime dateOfBirth)
        {
            Id = id;
            UserName = userName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}

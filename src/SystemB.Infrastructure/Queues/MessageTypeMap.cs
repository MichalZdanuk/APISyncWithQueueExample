using SystemA.Contracts.Events.Users;

namespace SystemB.Infrastructure.Queues
{
    public static class MessageTypeMap
    {
        public static readonly Dictionary<string, Type> EventTypeMap = new Dictionary<string, Type>
        {
            { "UserCreate", typeof(UserCreatedEvent) },
            { "UserUpdate", typeof(UserUpdatedEvent) }
        };
    }
}

namespace SystemB.Domain.Entities
{
    public class UserEventHistoricalRecord
    {
        private UserEventHistoricalRecord() { }

        public UserEventHistoricalRecord(Guid messageId, Guid userId, string messageBody, string eventType)
        {
            Id = Guid.NewGuid();
            MessageId = messageId;
            UserId = userId;
            MessageBody = messageBody;
            EventType = eventType;
            ActionDateTimeInUtc = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid MessageId { get; }
        public string MessageBody { get; }
        public string EventType { get; }
        public DateTime ActionDateTimeInUtc { get; }
    }
}

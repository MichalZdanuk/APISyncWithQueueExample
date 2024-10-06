namespace SystemB.Domain.Entities
{
    public class UserEventHistoricalRecord
    {
        private UserEventHistoricalRecord() { }

        public UserEventHistoricalRecord(Guid messageId, Guid userId, string messageBody)
        {
            Id = Guid.NewGuid();
            MessageId = messageId;
            UserId = userId;
            MessageBody = messageBody;
            ActionDateTimeInUtc = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid MessageId { get; }
        public string MessageBody { get; }
        public DateTime ActionDateTimeInUtc { get; }
    }
}

namespace SystemB.Application.DTOs.UserEventHistoricalRecords
{
    public class UserEventHistoricalRecordDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageId { get; set; }
        public string MessageBody { get; set; }
        public string EventType { get; set; }
        public DateTime ActionDateTimeInUtc { get; set; }
    }
}

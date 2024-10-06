using System.Text.Json;
using SystemA.Contracts.Events.Users;
using SystemB.Application.Repositories;
using SystemB.Domain.Entities;

namespace SystemB.Application.Events.External.Users
{
    public class UserUpdatedEventHandler(IUserEventHistoricalRecordRepository userEventHistoricalRecordRepository)
        : IEventHandler<UserUpdatedEvent>
    {
        public async Task Handle(UserUpdatedEvent @event)
        {
            Console.WriteLine($"User Updated Event Received: {@event.UserName}, {@event.Email}, {@event.DateOfBirth}");

            var userEventHistoricalRecord = PrepareUserEventHistoricalRecord(@event);

            await userEventHistoricalRecordRepository.AddAsync(userEventHistoricalRecord);
            await userEventHistoricalRecordRepository.SaveChangesAsync();
        }

        private UserEventHistoricalRecord PrepareUserEventHistoricalRecord(UserUpdatedEvent @event)
        {
            var messageBody = JsonSerializer.Serialize(@event);
            return new UserEventHistoricalRecord(@event.MessageId, @event.UserId,
                messageBody, @event.GetType().Name);
        }
    }
}

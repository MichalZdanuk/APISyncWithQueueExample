using System.Text.Json;
using SystemA.Contracts.Events.Users;
using SystemB.Application.Repositories;
using SystemB.Domain.Entities;

namespace SystemB.Application.Events.External.Users
{
    public class UserCreatedEventHandler(IUserEventHistoricalRecordRepository userEventHistoricalRecordRepository)
        : IEventHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent @event)
        {
            Console.WriteLine($"User Created Event Received: {@event.UserName}, {@event.Email}, {@event.DateOfBirth}");

            var userEventHistoricalRecord = PrepareUserEventHistoricalRecord(@event);

            await userEventHistoricalRecordRepository.AddAsync(userEventHistoricalRecord);
            await userEventHistoricalRecordRepository.SaveChangesAsync();
        }

        private UserEventHistoricalRecord PrepareUserEventHistoricalRecord(UserCreatedEvent @event)
        {
            var messageBody = JsonSerializer.Serialize(@event);
            return new UserEventHistoricalRecord(@event.MessageId, @event.UserId,
                messageBody, @event.GetType().Name);
        }
    }
}

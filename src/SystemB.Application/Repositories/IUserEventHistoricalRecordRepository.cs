using SystemB.Domain.Entities;

namespace SystemB.Application.Repositories
{
    public interface IUserEventHistoricalRecordRepository
    {
        public Task AddAsync(UserEventHistoricalRecord userEventHistoricalRecord);
        public Task SaveChangesAsync();
    }
}

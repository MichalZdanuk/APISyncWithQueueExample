using Microsoft.EntityFrameworkCore;
using SystemB.Application.Repositories;
using SystemB.Domain.Entities;
using SystemB.Infrastructure.Data;

namespace SystemB.Infrastructure.Repositories
{
    public class UserEventHistoricalRecordRepository(SystemBDbContext dbContext)
        : IUserEventHistoricalRecordRepository
    {
        public async Task AddAsync(UserEventHistoricalRecord userEventHistoricalRecord)
        {
            await dbContext.Set<UserEventHistoricalRecord>().AddAsync(userEventHistoricalRecord);
        }

        public async Task<IEnumerable<UserEventHistoricalRecord>> GetAllAsync()
        {
            return await dbContext.Set<UserEventHistoricalRecord>().ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}

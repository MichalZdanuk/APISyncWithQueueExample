using Microsoft.EntityFrameworkCore;
using SystemA.Application.Repositories;
using SystemA.Domain.Entities;
using SystemA.Infrastructure.Data;

namespace SystemA.Infrastructure.Repositories
{
    public class UserRepository(SystemADbContext dbContext) : IUserRepository
    {
        public void Add(User user)
        {
            dbContext.Set<User>().Add(user);
        }

        public async Task<User?> GetAsync(Guid id)
        {
            return await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}

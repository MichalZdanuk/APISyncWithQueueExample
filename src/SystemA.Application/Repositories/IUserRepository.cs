using SystemA.Domain.Entities;

namespace SystemA.Application.Repositories
{
    public interface IUserRepository
    {
        public void Add(User user);
        public Task<User?> GetAsync(Guid id);
        public Task SaveChangesAsync();
    }
}

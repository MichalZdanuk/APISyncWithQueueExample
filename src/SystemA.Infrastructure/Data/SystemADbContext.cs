using Microsoft.EntityFrameworkCore;
using SystemA.Domain.Entities;
using SystemA.Infrastructure.Configurations;

namespace SystemA.Infrastructure.Data
{
    public class SystemADbContext : DbContext
    {
        public SystemADbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);

            modelBuilder.HasDefaultSchema("SystemA");
        }
    }
}

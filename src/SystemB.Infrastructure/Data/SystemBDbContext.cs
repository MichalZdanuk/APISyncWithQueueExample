using Microsoft.EntityFrameworkCore;
using SystemB.Domain.Entities;
using SystemB.Infrastructure.Configurations;

namespace SystemB.Infrastructure.Data
{
    public class SystemBDbContext : DbContext
    {
        public SystemBDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UserEventHistoricalRecord> UserEventHistoricalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEventHistoricalRecordConfiguration).Assembly);

            modelBuilder.HasDefaultSchema("SystemB");
        }
    }
}

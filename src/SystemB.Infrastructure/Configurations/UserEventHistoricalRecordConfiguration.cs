using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SystemB.Domain.Entities;

namespace SystemB.Infrastructure.Configurations
{
    public class UserEventHistoricalRecordConfiguration : IEntityTypeConfiguration<UserEventHistoricalRecord>
    {
        public void Configure(EntityTypeBuilder<UserEventHistoricalRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.MessageId)
                .IsRequired();

            builder.Property(x => x.MessageBody)
                .IsRequired();

            builder.Property(x => x.EventType)
                .IsRequired();

            builder.Property(x => x.ActionDateTimeInUtc)
                .IsRequired();
        }
    }
}

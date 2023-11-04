using InTime.Keys.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace InTime.Keys.Persistence.Contexts.EfCore.Configurations;

public class TimeSlotCfg : IEntityTypeConfiguration<TimeSlot>
{
    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Ignore(e => e.DomainEvents);
    }
}
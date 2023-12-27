using InTime.Keys.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InTime.Keys.Persistence.Contexts.EfCore.Configurations;

public class KeyTransferCfg : IEntityTypeConfiguration<KeyTransfer>
{
    public void Configure(EntityTypeBuilder<KeyTransfer> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Ignore(e => e.DomainEvents);
    }
}

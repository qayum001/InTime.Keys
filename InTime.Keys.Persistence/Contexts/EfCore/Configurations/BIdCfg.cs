using InTime.Keys.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InTime.Keys.Persistence.Contexts.EfCore.Configurations;

public class BIdCfg : IEntityTypeConfiguration<Bid>
{
    public void Configure(EntityTypeBuilder<Bid> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Ignore(e => e.DomainEvents);
    }
}
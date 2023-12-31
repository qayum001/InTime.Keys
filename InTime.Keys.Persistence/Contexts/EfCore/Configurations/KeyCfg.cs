﻿using InTime.Keys.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InTime.Keys.Persistence.Contexts.EfCore.Configurations;

public class KeyCfg : IEntityTypeConfiguration<Key>
{
    public void Configure(EntityTypeBuilder<Key> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Ignore(e => e.DomainEvents);
    }
}

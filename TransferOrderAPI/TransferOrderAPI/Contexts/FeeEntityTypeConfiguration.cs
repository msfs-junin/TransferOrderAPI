using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contexts
{
    public class FeeEntityTypeConfiguration : IEntityTypeConfiguration<Fee>
    {
        public void Configure(EntityTypeBuilder<Fee> builder)
        {
            builder.HasKey((Fee f) => (object)f.Id);
            builder.Property(f => f.Id).IsRequired();
            builder.Property<Guid>((Fee f) => f.Id).IsRequired(true);
            builder.Property<string>((Fee f) => f.source).IsRequired(true).HasMaxLength(3);
            builder.Property<string>((Fee f) => f.destination).IsRequired(true).HasMaxLength(3);
            builder.Property<decimal>((Fee f) => f.rate).IsRequired(true);
            builder.Property<int>((Fee f) => f.timestamp).IsRequired(true);
            builder.HasData(new Fee[] { new Fee()
        {
            Id = new Guid("d28868e9-2ba9-473a-a40f-e38cb54f9b35"),
            source = "USD",
            destination = "ARS",
            rate = 10.0M,
            timestamp = 12345678
        }});

        }
    }
}
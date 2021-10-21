using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Contexts
{
    public class TransferOrderEntityTypeConfiguration : IEntityTypeConfiguration<TransferOrder>
    {
        public void Configure(EntityTypeBuilder<TransferOrder> builder)
        {
            builder.HasKey((TransferOrder t) => (object)t.Id);
            builder.Property(t => t.Id).IsRequired();
            builder.Property<Guid>((TransferOrder t) => t.Id).IsRequired(true);
            builder.Property<string>((TransferOrder t) => t.sourceCurrency).IsRequired(true).HasMaxLength(3);
            builder.Property<string>((TransferOrder t) => t.destinationCurrency).IsRequired(true).HasMaxLength(3);
            builder.HasData(new TransferOrder[] { new TransferOrder()
            {
                Id = new Guid("d28868e9-2ba9-473a-a40f-e38cb54f9b35"),
                sourceCurrency = "USD",
                destinationCurrency = "ARS",
                netAmmount = 10000.00M,
                grossAmmount = 0M
            }});

        }
    }
}

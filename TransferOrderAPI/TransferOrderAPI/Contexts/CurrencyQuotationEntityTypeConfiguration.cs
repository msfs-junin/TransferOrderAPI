using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Contexts
{
    public class CurrencyQuotationEntityTypeConfiguration : IEntityTypeConfiguration<CurrencyQuotation>
    {
        public void Configure(EntityTypeBuilder<CurrencyQuotation> builder)
        {
            builder.HasKey((CurrencyQuotation q) => (object)q.Id);
            builder.Property(b => b.Id).IsRequired();
            builder.Property<int>((CurrencyQuotation q) => q.Id).IsRequired(true);
            builder.Property<string>((CurrencyQuotation q) => q.source).IsRequired(true).HasMaxLength(3);
            builder.Property<string>((CurrencyQuotation q) => q.destination).IsRequired(true).HasMaxLength(3);
            builder.Property<int>((CurrencyQuotation q) => q.timestamp).IsRequired(true);
            builder.HasData(new CurrencyQuotation[] { new CurrencyQuotation()
            {
                Id = 1,
                source = "USD",
                destination = "ARS",
                rate = new decimal(99148817, 0, 0, false, 6),
                timestamp = 1634371754
            }, new CurrencyQuotation()
            {
                Id = 2,
                source = "USD",
                destination = "AED",
                rate = new decimal(3673104, 0, 0, false, 6),
                timestamp = 1634371754
            }, new CurrencyQuotation()
            {
                Id = 3,
                source = "USD",
                destination = "AFN",
                rate = new decimal(89350404, 0, 0, false, 6),
                timestamp = 1634371754
            }, new CurrencyQuotation()
            {
                Id = 4,
                source = "USD",
                destination = "ALL",
                rate = new decimal(104803989, 0, 0, false, 6),
                timestamp = 1634371754
            }, new CurrencyQuotation()
            {
                Id = 5,
                source = "USD",
                destination = "AMD",
                rate = new decimal(478420403, 0, 0, false, 6),
                timestamp = 1634371754
            } });

        }
    }
}
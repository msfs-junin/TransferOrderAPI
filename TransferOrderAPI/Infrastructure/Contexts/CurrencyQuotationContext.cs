using Microsoft.EntityFrameworkCore;
using System;
using Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Contexts
{
    public class CurrencyQuotationContext : DbContext
    {
        public DbSet<CurrencyQuotation> CurrencyQuotations { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RelationalEntityTypeBuilderExtensions.ToTable<CurrencyQuotation>(modelBuilder.Entity<CurrencyQuotation>(), "CurrencyQuotations");
            new CurrencyQuotationEntityTypeConfiguration().Configure(modelBuilder.Entity<CurrencyQuotation>());
        }
    }
}

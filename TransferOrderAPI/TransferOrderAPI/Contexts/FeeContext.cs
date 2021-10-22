using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Contexts
{
    public class FeeContext: DbContext
    {
        public DbSet<Fee> Fees { get; set; }

        public FeeContext(DbContextOptions<FeeContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RelationalEntityTypeBuilderExtensions.ToTable<Fee>(modelBuilder.Entity<Fee>(), "Fees");
            new FeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Fee>());
        }
    }
}

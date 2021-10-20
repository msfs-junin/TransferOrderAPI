using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Contexts
{
    public class FeeContext : DbContext
    {
        public DbSet<Fee> Fees { get; set; }

        public FeeContext(DbContextOptions<FeeContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

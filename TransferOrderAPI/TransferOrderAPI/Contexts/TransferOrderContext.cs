using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Contexts
{
    public class TransferOrderContext : DbContext
    {
        public DbSet<TransferOrder> TransferOrders { get; set; }
        public TransferOrderContext(DbContextOptions<TransferOrderContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RelationalEntityTypeBuilderExtensions.ToTable<TransferOrder>(modelBuilder.Entity<TransferOrder>(), "TransferOrders");
            new TransferOrderEntityTypeConfiguration().Configure(modelBuilder.Entity<TransferOrder>());
        }
    }
}

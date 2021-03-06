// <auto-generated />
using System;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(TransferOrderContext))]
    [Migration("20211021121032_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Entities.TransferOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("destinationCurrency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<decimal>("grossAmmount")
                        .HasColumnType("decimal(24,6)");

                    b.Property<decimal>("netAmmount")
                        .HasColumnType("decimal(24,6)");

                    b.Property<string>("sourceCurrency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("TransferOrders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28868e9-2ba9-473a-a40f-e38cb54f9b35"),
                            destinationCurrency = "ARS",
                            grossAmmount = 0m,
                            netAmmount = 10000.00m,
                            sourceCurrency = "USD"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

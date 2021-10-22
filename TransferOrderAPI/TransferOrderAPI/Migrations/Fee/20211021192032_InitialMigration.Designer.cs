﻿// <auto-generated />
using System;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations.Fee
{
    [DbContext(typeof(FeeContext))]
    [Migration("20211021192032_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Entities.Fee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<decimal>("rate")
                        .HasColumnType("decimal(24,6)");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("timestamp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28868e9-2ba9-473a-a40f-e38cb54f9b35"),
                            destination = "ARS",
                            rate = 10.0m,
                            source = "USD",
                            timestamp = 12345678
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

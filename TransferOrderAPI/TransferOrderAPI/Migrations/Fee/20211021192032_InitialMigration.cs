using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations.Fee
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    source = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    destination = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    rate = table.Column<decimal>(type: "decimal(24,6)", nullable: false),
                    timestamp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "Id", "destination", "rate", "source", "timestamp" },
                values: new object[] { new Guid("d28868e9-2ba9-473a-a40f-e38cb54f9b35"), "ARS", 10.0m, "USD", 12345678 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fees");
        }
    }
}

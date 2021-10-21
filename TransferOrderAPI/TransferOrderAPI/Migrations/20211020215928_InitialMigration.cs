using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransferOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sourceCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    destinationCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    netAmmount = table.Column<decimal>(type: "decimal(24,6)", nullable: false),
                    grossAmmount = table.Column<decimal>(type: "decimal(24,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOrders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TransferOrders",
                columns: new[] { "Id", "destinationCurrency", "grossAmmount", "netAmmount", "sourceCurrency" },
                values: new object[] { new Guid("d28868e9-2ba9-473a-a40f-e38cb54f9b35"), "ARS", 0m, 10000.00m, "USD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferOrders");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations.CurrencyQuotation
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyQuotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    destination = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    timestamp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyQuotations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CurrencyQuotations",
                columns: new[] { "Id", "destination", "rate", "source", "timestamp" },
                values: new object[,]
                {
                    { 1, "ARS", 99.148817m, "USD", 1634371754 },
                    { 2, "AED", 3.673104m, "USD", 1634371754 },
                    { 3, "AFN", 89.350404m, "USD", 1634371754 },
                    { 4, "ALL", 104.803989m, "USD", 1634371754 },
                    { 5, "AMD", 478.420403m, "USD", 1634371754 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyQuotations");
        }
    }
}

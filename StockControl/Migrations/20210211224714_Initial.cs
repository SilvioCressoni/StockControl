using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockControl.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTrade = table.Column<DateTime>(nullable: false),
                    Corretora = table.Column<string>(nullable: false),
                    Stock = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    TypeOperation = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    ValorUnit = table.Column<double>(nullable: false),
                    ValorTotalTraded = table.Column<double>(nullable: false),
                    StatusOperation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");
        }
    }
}

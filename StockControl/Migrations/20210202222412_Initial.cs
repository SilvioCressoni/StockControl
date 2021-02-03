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
                name: "TaxOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorCblc = table.Column<double>(nullable: false),
                    ValorEmolumentos = table.Column<double>(nullable: false),
                    ValorCorretagem = table.Column<double>(nullable: false),
                    ValorIss = table.Column<double>(nullable: false),
                    ValorIrrf = table.Column<double>(nullable: false),
                    ValorTotalTax = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTrade = table.Column<DateTime>(nullable: false),
                    Corretora = table.Column<string>(nullable: true),
                    TypeOperation = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    ValorUnit = table.Column<double>(nullable: false),
                    ValorTotalTraded = table.Column<double>(nullable: false),
                    StatusOperation = table.Column<int>(nullable: false),
                    TaxOperationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_TaxOperation_TaxOperationId",
                        column: x => x.TaxOperationId,
                        principalTable: "TaxOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StockName = table.Column<string>(nullable: true),
                    NameCompany = table.Column<string>(nullable: true),
                    Sector = table.Column<int>(nullable: false),
                    OperationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_TaxOperationId",
                table: "Operation",
                column: "TaxOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_OperationId",
                table: "Stock",
                column: "OperationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "TaxOperation");
        }
    }
}

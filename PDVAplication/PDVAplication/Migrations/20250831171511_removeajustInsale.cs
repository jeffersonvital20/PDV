using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDVAplication.Migrations
{
    /// <inheritdoc />
    public partial class removeajustInsale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Sales_SalesModelId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SalesModelId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SalesModelId",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductModelSalesModel",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelSalesModel", x => new { x.ProductsId, x.SalesId });
                    table.ForeignKey(
                        name: "FK_ProductModelSalesModel_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelSalesModel_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelSalesModel_SalesId",
                table: "ProductModelSalesModel",
                column: "SalesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductModelSalesModel");

            migrationBuilder.AddColumn<Guid>(
                name: "SalesModelId",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SalesModelId",
                table: "Product",
                column: "SalesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Sales_SalesModelId",
                table: "Product",
                column: "SalesModelId",
                principalTable: "Sales",
                principalColumn: "Id");
        }
    }
}

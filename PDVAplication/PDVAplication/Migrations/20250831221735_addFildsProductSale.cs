using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDVAplication.Migrations
{
    /// <inheritdoc />
    public partial class addFildsProductSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Sales");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountProduct",
                table: "ProductSales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceProduct",
                table: "ProductSales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountProduct",
                table: "ProductSales");

            migrationBuilder.DropColumn(
                name: "PriceProduct",
                table: "ProductSales");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Sales",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Sales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

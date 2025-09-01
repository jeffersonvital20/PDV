using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDVAplication.Migrations
{
    /// <inheritdoc />
    public partial class AddFKSaleAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Sales",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SaleId",
                table: "Product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Product");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDVAplication.Migrations
{
    /// <inheritdoc />
    public partial class AddSellerInSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "Sales",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Customer",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seller",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Customer");
        }
    }
}

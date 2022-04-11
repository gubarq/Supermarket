using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Database.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Availability",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Availability");
        }
    }
}

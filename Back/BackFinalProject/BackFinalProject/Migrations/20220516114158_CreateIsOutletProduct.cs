using Microsoft.EntityFrameworkCore.Migrations;

namespace BackFinalProject.Migrations
{
    public partial class CreateIsOutletProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOutlet",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOutlet",
                table: "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BackFinalProject.Migrations
{
    public partial class CreateCategorySubCategoryTextBrendIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubCategoryText",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryText",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brends",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryText",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CategoryText",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brends");
        }
    }
}

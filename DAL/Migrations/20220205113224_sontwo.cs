using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class sontwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuarterTitlesId",
                table: "QuarterCategoryTitles",
                newName: "QuarterCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuarterCategoryId",
                table: "QuarterCategoryTitles",
                newName: "QuarterTitlesId");
        }
    }
}

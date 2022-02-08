using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class FKRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuarterCategoryTitles_QuarterCategories_ObjQuarterTitlesId",
                table: "QuarterCategoryTitles");

            migrationBuilder.RenameColumn(
                name: "ObjQuarterTitlesId",
                table: "QuarterCategoryTitles",
                newName: "ObjQuarterCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_QuarterCategoryTitles_ObjQuarterTitlesId",
                table: "QuarterCategoryTitles",
                newName: "IX_QuarterCategoryTitles_ObjQuarterCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuarterCategoryTitles_QuarterCategories_ObjQuarterCategoryId",
                table: "QuarterCategoryTitles",
                column: "ObjQuarterCategoryId",
                principalTable: "QuarterCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuarterCategoryTitles_QuarterCategories_ObjQuarterCategoryId",
                table: "QuarterCategoryTitles");

            migrationBuilder.RenameColumn(
                name: "ObjQuarterCategoryId",
                table: "QuarterCategoryTitles",
                newName: "ObjQuarterTitlesId");

            migrationBuilder.RenameIndex(
                name: "IX_QuarterCategoryTitles_ObjQuarterCategoryId",
                table: "QuarterCategoryTitles",
                newName: "IX_QuarterCategoryTitles_ObjQuarterTitlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuarterCategoryTitles_QuarterCategories_ObjQuarterTitlesId",
                table: "QuarterCategoryTitles",
                column: "ObjQuarterTitlesId",
                principalTable: "QuarterCategories",
                principalColumn: "Id");
        }
    }
}

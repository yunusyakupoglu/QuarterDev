using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ForeignKeyRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuarterTitlesLists_QuarterTitles_QuarterTitlesId",
                table: "QuarterTitlesLists");

            migrationBuilder.DropIndex(
                name: "IX_QuarterTitlesLists_QuarterTitlesId",
                table: "QuarterTitlesLists");

            migrationBuilder.AddColumn<int>(
                name: "ObjQuarterTitlesId",
                table: "QuarterTitlesLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuarterTitlesLists_ObjQuarterTitlesId",
                table: "QuarterTitlesLists",
                column: "ObjQuarterTitlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuarterTitlesLists_QuarterTitles_ObjQuarterTitlesId",
                table: "QuarterTitlesLists",
                column: "ObjQuarterTitlesId",
                principalTable: "QuarterTitles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuarterTitlesLists_QuarterTitles_ObjQuarterTitlesId",
                table: "QuarterTitlesLists");

            migrationBuilder.DropIndex(
                name: "IX_QuarterTitlesLists_ObjQuarterTitlesId",
                table: "QuarterTitlesLists");

            migrationBuilder.DropColumn(
                name: "ObjQuarterTitlesId",
                table: "QuarterTitlesLists");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterTitlesLists_QuarterTitlesId",
                table: "QuarterTitlesLists",
                column: "QuarterTitlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuarterTitlesLists_QuarterTitles_QuarterTitlesId",
                table: "QuarterTitlesLists",
                column: "QuarterTitlesId",
                principalTable: "QuarterTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class foreignKeysRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUDescriptions_aboutUses_AboutUsId",
                table: "AUDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_AUDescriptions_AboutUsId",
                table: "AUDescriptions");

            migrationBuilder.AddColumn<int>(
                name: "ObjAboutUsId",
                table: "AUDescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUDescriptions_ObjAboutUsId",
                table: "AUDescriptions",
                column: "ObjAboutUsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUDescriptions_aboutUses_ObjAboutUsId",
                table: "AUDescriptions",
                column: "ObjAboutUsId",
                principalTable: "aboutUses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUDescriptions_aboutUses_ObjAboutUsId",
                table: "AUDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_AUDescriptions_ObjAboutUsId",
                table: "AUDescriptions");

            migrationBuilder.DropColumn(
                name: "ObjAboutUsId",
                table: "AUDescriptions");

            migrationBuilder.CreateIndex(
                name: "IX_AUDescriptions_AboutUsId",
                table: "AUDescriptions",
                column: "AboutUsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUDescriptions_aboutUses_AboutUsId",
                table: "AUDescriptions",
                column: "AboutUsId",
                principalTable: "aboutUses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

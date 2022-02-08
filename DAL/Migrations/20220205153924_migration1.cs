using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorySubtitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    QuarterCategoryTitleId = table.Column<int>(type: "int", nullable: false),
                    ObjQuarterCategoryTitleId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySubtitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategorySubtitles_QuarterCategoryTitles_ObjQuarterCategoryTitleId",
                        column: x => x.ObjQuarterCategoryTitleId,
                        principalTable: "QuarterCategoryTitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubtitleDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CategoySubtitleId = table.Column<int>(type: "int", nullable: false),
                    ObjCategorySubtitleId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubtitleDescriptions_CategorySubtitles_ObjCategorySubtitleId",
                        column: x => x.ObjCategorySubtitleId,
                        principalTable: "CategorySubtitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubtitleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CategoySubtitleId = table.Column<int>(type: "int", nullable: false),
                    ObjCategorySubtitleId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubtitleItems_CategorySubtitles_ObjCategorySubtitleId",
                        column: x => x.ObjCategorySubtitleId,
                        principalTable: "CategorySubtitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubtitles_ObjQuarterCategoryTitleId",
                table: "CategorySubtitles",
                column: "ObjQuarterCategoryTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleDescriptions_ObjCategorySubtitleId",
                table: "SubtitleDescriptions",
                column: "ObjCategorySubtitleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleItems_ObjCategorySubtitleId",
                table: "SubtitleItems",
                column: "ObjCategorySubtitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubtitleDescriptions");

            migrationBuilder.DropTable(
                name: "SubtitleItems");

            migrationBuilder.DropTable(
                name: "CategorySubtitles");
        }
    }
}

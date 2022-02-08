﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class NameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuarterTitlesLists");

            migrationBuilder.DropTable(
                name: "QuarterTitles");

            migrationBuilder.CreateTable(
                name: "QuarterCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuarterCategoryTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    QuarterTitlesId = table.Column<int>(type: "int", nullable: false),
                    ObjQuarterTitlesId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterCategoryTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuarterCategoryTitles_QuarterCategories_ObjQuarterTitlesId",
                        column: x => x.ObjQuarterTitlesId,
                        principalTable: "QuarterCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuarterCategoryTitles_ObjQuarterTitlesId",
                table: "QuarterCategoryTitles",
                column: "ObjQuarterTitlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuarterCategoryTitles");

            migrationBuilder.DropTable(
                name: "QuarterCategories");

            migrationBuilder.CreateTable(
                name: "QuarterTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuarterTitlesLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjQuarterTitlesId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuarterTitlesId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterTitlesLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuarterTitlesLists_QuarterTitles_ObjQuarterTitlesId",
                        column: x => x.ObjQuarterTitlesId,
                        principalTable: "QuarterTitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuarterTitlesLists_ObjQuarterTitlesId",
                table: "QuarterTitlesLists",
                column: "ObjQuarterTitlesId");
        }
    }
}

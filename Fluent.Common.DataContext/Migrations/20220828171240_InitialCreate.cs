using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fluent.Common.DataContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardRevision",
                columns: table => new
                {
                    FlashCardsId = table.Column<int>(type: "int", nullable: false),
                    RevisionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardRevision", x => new { x.FlashCardsId, x.RevisionsId });
                    table.ForeignKey(
                        name: "FK_FlashCardRevision_FlashCards_FlashCardsId",
                        column: x => x.FlashCardsId,
                        principalTable: "FlashCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashCardRevision_Revisions_RevisionsId",
                        column: x => x.RevisionsId,
                        principalTable: "Revisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardRevision_RevisionsId",
                table: "FlashCardRevision",
                column: "RevisionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCardRevision");

            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "Revisions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class KeywordNPraN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_keywords_Revistas_RevistaId",
                table: "keywords");

            migrationBuilder.DropIndex(
                name: "IX_keywords_RevistaId",
                table: "keywords");

            migrationBuilder.DropColumn(
                name: "RevistaId",
                table: "keywords");

            migrationBuilder.CreateTable(
                name: "RevistaKeyword",
                columns: table => new
                {
                    RevistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeywordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevistaKeyword", x => new { x.RevistaId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_RevistaKeyword_Revistas_RevistaId",
                        column: x => x.RevistaId,
                        principalTable: "Revistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RevistaKeyword_keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RevistaKeyword_KeywordId",
                table: "RevistaKeyword",
                column: "KeywordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevistaKeyword");

            migrationBuilder.AddColumn<Guid>(
                name: "RevistaId",
                table: "keywords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_keywords_RevistaId",
                table: "keywords",
                column: "RevistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_keywords_Revistas_RevistaId",
                table: "keywords",
                column: "RevistaId",
                principalTable: "Revistas",
                principalColumn: "Id");
        }
    }
}

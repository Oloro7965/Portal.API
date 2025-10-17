using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class KeywordUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "keywords",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "keywords");
        }
    }
}

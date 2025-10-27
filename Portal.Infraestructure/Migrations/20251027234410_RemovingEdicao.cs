using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingEdicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "edicao",
                table: "Revistas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "edicao",
                table: "Revistas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

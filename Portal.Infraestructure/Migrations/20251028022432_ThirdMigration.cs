using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "capa",
                table: "Revistas",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Revistas",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Artigos",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "capa",
                table: "Revistas",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Revistas",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Artigos",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}

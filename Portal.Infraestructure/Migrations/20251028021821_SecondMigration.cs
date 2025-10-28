using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Revistas",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Artigos",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Revistas",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "arquivopdf",
                table: "Artigos",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}

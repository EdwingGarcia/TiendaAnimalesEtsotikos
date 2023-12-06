using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAnimalesEtsotikos.Migrations
{
    /// <inheritdoc />
    public partial class agf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Propietario",
                table: "Animal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2,
                column: "Propietario",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Propietario",
                table: "Animal",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2,
                column: "Propietario",
                value: null);
        }
    }
}

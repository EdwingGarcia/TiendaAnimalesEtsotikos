using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAnimalesEtsotikos.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enfermedad", "Nombre" },
                values: new object[] { "Sin un ojo", "DODO" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enfermedad", "Nombre" },
                values: new object[] { "tos", "perro" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enfermedad", "Nombre" },
                values: new object[] { "gonorrea", "Carlos" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enfermedad", "Nombre" },
                values: new object[] { "estudiar derecho", "Julian" });
        }
    }
}

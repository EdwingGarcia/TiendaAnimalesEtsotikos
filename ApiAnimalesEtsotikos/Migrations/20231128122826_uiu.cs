using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAnimalesEtsotikos.Migrations
{
    /// <inheritdoc />
    public partial class uiu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Animal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img",
                value: "https://as01.epimg.net/diarioas/imagenes/2022/05/29/actualidad/1653826510_995351_1653826595_noticia_normal_recorte1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Animal");

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "Altura", "Enfermedad", "Nombre", "NombreCientifico", "PaisOrigen", "Peso", "Propietario", "Status" },
                values: new object[] { 1, 6.5f, "Sin un ojo", "DODO", "popo", "Sudamérica del Norte", 54f, null, 0 });
        }
    }
}

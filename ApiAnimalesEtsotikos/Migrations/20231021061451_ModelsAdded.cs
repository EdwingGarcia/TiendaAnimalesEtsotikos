using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiAnimalesEtsotikos.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Propietario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cedula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalComprado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cedula);
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "Altura", "Enfermedad", "Nombre", "NombreCientifico", "PaisOrigen", "Peso", "Propietario", "Status" },
                values: new object[,]
                {
                    { 1, 6.5f, "gonorrea", "Carlos", "popo", "Sudamérica del Norte", 54f, null, 0 },
                    { 2, 2.4f, "estudiar derecho", "Julian", "pipi", "Norteamérica del Sur", 22f, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Cedula", "AnimalComprado", "Direccion", "Nombre" },
                values: new object[] { 1723124796, null, "Conocoto", "Edwing" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

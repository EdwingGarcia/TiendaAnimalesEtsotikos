using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiAnimalesEtsotikos.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    NombreVeterinario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DireccionVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoVeterinario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.NombreVeterinario);
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "Altura", "Enfermedad", "Nombre", "NombreCientifico", "PaisOrigen", "Peso", "Propietario", "Status" },
                values: new object[,]
                {
                    { 1, 6.5f, "Sin un ojo", "DODO", "popo", "Sudamérica del Norte", 54f, null, 0 },
                    { 2, 2.4f, "tos", "perro", "pipi", "Norteamérica del Sur", 22f, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Cedula", "Direccion", "Nombre", "Password" },
                values: new object[] { 1723124796, "Conocoto", "Edwing", "password" });

            migrationBuilder.InsertData(
                table: "Veterinario",
                columns: new[] { "NombreVeterinario", "DireccionVeterinario", "TelefonoVeterinario" },
                values: new object[] { "Patitas del Saber", "cuba", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Veterinario");
        }
    }
}

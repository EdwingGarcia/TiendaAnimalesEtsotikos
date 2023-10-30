using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAnimalesEtsotikos.Migrations
{
    /// <inheritdoc />
    public partial class aSys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalComprado",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalComprado",
                table: "Cliente",
                type: "int",
                nullable: true);
        }
    }
}

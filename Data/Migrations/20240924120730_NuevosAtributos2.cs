using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class NuevosAtributos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaEmpresa",
                table: "Peticiones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCiudadEmpresa",
                table: "Peticiones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCategoriaEmpresa",
                table: "Peticiones");

            migrationBuilder.DropColumn(
                name: "IdCiudadEmpresa",
                table: "Peticiones");
        }
    }
}

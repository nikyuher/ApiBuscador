using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class nuevosAtributosPeticiones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorreoEmpresa",
                table: "Peticiones",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SitioWebEmpresa",
                table: "Peticiones",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TelefonoEmpresa",
                table: "Peticiones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorreoEmpresa",
                table: "Peticiones");

            migrationBuilder.DropColumn(
                name: "SitioWebEmpresa",
                table: "Peticiones");

            migrationBuilder.DropColumn(
                name: "TelefonoEmpresa",
                table: "Peticiones");
        }
    }
}

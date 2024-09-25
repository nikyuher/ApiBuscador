using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class cambioNameAtributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peticiones_Usuarios_UsuarioId",
                table: "Peticiones");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Peticiones",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Peticiones_UsuarioId",
                table: "Peticiones",
                newName: "IX_Peticiones_IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Peticiones_Usuarios_IdUsuario",
                table: "Peticiones",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peticiones_Usuarios_IdUsuario",
                table: "Peticiones");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Peticiones",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Peticiones_IdUsuario",
                table: "Peticiones",
                newName: "IX_Peticiones_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peticiones_Usuarios_UsuarioId",
                table: "Peticiones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

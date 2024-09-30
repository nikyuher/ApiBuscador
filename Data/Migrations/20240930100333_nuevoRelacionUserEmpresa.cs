using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class nuevoRelacionUserEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioEmpresas",
                columns: table => new
                {
                    IdUsuarioEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmpresas", x => x.IdUsuarioEmpresa);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresas_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresas_IdEmpresa",
                table: "UsuarioEmpresas",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresas_IdUsuario",
                table: "UsuarioEmpresas",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEmpresas");
        }
    }
}

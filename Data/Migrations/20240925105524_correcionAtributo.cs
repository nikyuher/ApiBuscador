using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class correcionAtributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peticiones_Empresas_EmpresaId",
                table: "Peticiones");

            migrationBuilder.DropIndex(
                name: "IX_Peticiones_EmpresaId",
                table: "Peticiones");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Peticiones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Peticiones_EmpresaId",
                table: "Peticiones",
                column: "EmpresaId",
                unique: true,
                filter: "[EmpresaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Peticiones_Empresas_EmpresaId",
                table: "Peticiones",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peticiones_Empresas_EmpresaId",
                table: "Peticiones");

            migrationBuilder.DropIndex(
                name: "IX_Peticiones_EmpresaId",
                table: "Peticiones");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Peticiones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peticiones_EmpresaId",
                table: "Peticiones",
                column: "EmpresaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Peticiones_Empresas_EmpresaId",
                table: "Peticiones",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class correcionModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peticiones_Empresas_EmpresaId",
                table: "Peticiones");

            migrationBuilder.DropIndex(
                name: "IX_Peticiones_EmpresaId",
                table: "Peticiones");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Peticiones");

            migrationBuilder.AddColumn<int>(
                name: "PeticionIdPeticion",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_PeticionIdPeticion",
                table: "Empresas",
                column: "PeticionIdPeticion");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Peticiones_PeticionIdPeticion",
                table: "Empresas",
                column: "PeticionIdPeticion",
                principalTable: "Peticiones",
                principalColumn: "IdPeticion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Peticiones_PeticionIdPeticion",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_PeticionIdPeticion",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "PeticionIdPeticion",
                table: "Empresas");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Peticiones",
                type: "int",
                nullable: true);

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class CambiarContraseñaHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordChangedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordChangedAt",
                table: "Usuarios");
        }
    }
}

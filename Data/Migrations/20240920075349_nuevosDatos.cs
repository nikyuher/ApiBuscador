using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class nuevosDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 1,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/inditexLC.jpg?updatedAt=1726649179851");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 2,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/santander.jpg?updatedAt=1726649877238");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 3,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/telefonica.jpg?updatedAt=1726649877081");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 4,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/iberdrola-.jpg?updatedAt=1726649877427");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 5,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 6,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/elcorteingles.jpeg?updatedAt=1726649879087");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 7,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/caixabanck.jpg?updatedAt=1726649879170");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 8,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/seat.jpg?updatedAt=1726649876969");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 9,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/aena-aeropuerto.jpg?updatedAt=1726649877286");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 10,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpeg?updatedAt=1726649879406");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 11,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/mafre.jpg?updatedAt=1726649877454");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 12,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/acciona.webp?updatedAt=1726649877393");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 13,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/BBVA.jpg?updatedAt=1726649879175");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 14,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/amadeus.jpg?updatedAt=1726649879691");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 15,
                column: "Imagen",
                value: "https://ik.imagekit.io/Mariocanizares/Empresas/grifols.jpg?updatedAt=1726649877212");

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "IdEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { 16, "Una de las mayores marcas de moda del mundo.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://ik.imagekit.io/Mariocanizares/Empresas/zara.jpg?updatedAt=1726649877219", "Zara" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 1,
                column: "Imagen",
                value: "https://example.com/inditex.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 2,
                column: "Imagen",
                value: "https://example.com/santander.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 3,
                column: "Imagen",
                value: "https://example.com/telefonica.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 4,
                column: "Imagen",
                value: "https://example.com/iberdrola.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 5,
                column: "Imagen",
                value: "https://example.com/repsol.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 6,
                column: "Imagen",
                value: "https://example.com/elcorteingles.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 7,
                column: "Imagen",
                value: "https://example.com/caixabank.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 8,
                column: "Imagen",
                value: "https://example.com/seat.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 9,
                column: "Imagen",
                value: "https://example.com/aena.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 10,
                column: "Imagen",
                value: "https://example.com/ferrovial.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 11,
                column: "Imagen",
                value: "https://example.com/mapfre.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 12,
                column: "Imagen",
                value: "https://example.com/acciona.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 13,
                column: "Imagen",
                value: "https://example.com/bbva.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 14,
                column: "Imagen",
                value: "https://example.com/amadeus.png");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 15,
                column: "Imagen",
                value: "https://example.com/grifols.png");

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "IdEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { 30, "Una de las mayores marcas de moda del mundo.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://example.com/zara.png", "Zara" });
        }
    }
}

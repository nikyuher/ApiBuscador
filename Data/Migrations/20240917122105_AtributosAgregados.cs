using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class AtributosAgregados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ciudadades",
                columns: new[] { "IdCiudad", "Nombre" },
                values: new object[,]
                {
                    { 1, "Madrid" },
                    { 2, "Barcelona" },
                    { 3, "Valencia" },
                    { 4, "Sevilla" },
                    { 5, "Zaragoza" },
                    { 6, "Málaga" },
                    { 7, "Murcia" },
                    { 8, "Palma de Mallorca" },
                    { 9, "Las Palmas de Gran Canaria" },
                    { 10, "Bilbao" },
                    { 11, "Alicante" },
                    { 12, "Córdoba" },
                    { 13, "Valladolid" },
                    { 14, "Vigo" },
                    { 15, "Gijón" },
                    { 16, "Eibar" },
                    { 17, "Tarragona" },
                    { 18, "Lérida" },
                    { 19, "Huelva" },
                    { 20, "Granada" },
                    { 21, "Jaén" },
                    { 22, "Almería" },
                    { 23, "Toledo" },
                    { 24, "Salamanca" },
                    { 25, "Segovia" },
                    { 26, "Soria" },
                    { 27, "Badajoz" },
                    { 28, "Cáceres" },
                    { 29, "Logroño" },
                    { 30, "Pamplona" }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "IdEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[,]
                {
                    { 1, "Líder mundial en distribución de moda.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://example.com/inditex.png", "Inditex" },
                    { 2, "Una de las mayores entidades bancarias del mundo.", "Ciudad Grupo Santander, 28660 Boadilla del Monte, Madrid", "https://example.com/santander.png", "Banco Santander" },
                    { 3, "Multinacional española de telecomunicaciones.", "Distrito Telefónica, 28050 Madrid", "https://example.com/telefonica.png", "Telefónica" },
                    { 4, "Una de las mayores empresas energéticas del mundo.", "Plaza Euskadi 5, 48009 Bilbao", "https://example.com/iberdrola.png", "Iberdrola" },
                    { 5, "Empresa energética multinacional española.", "Calle Méndez Álvaro, 44, 28045 Madrid", "https://example.com/repsol.png", "Repsol" },
                    { 6, "Cadena de grandes almacenes más grande de Europa.", "Calle Hermosilla, 112, 28009 Madrid", "https://example.com/elcorteingles.png", "El Corte Inglés" },
                    { 7, "Uno de los bancos más importantes de España.", "Av. Diagonal, 621, 08028 Barcelona", "https://example.com/caixabank.png", "CaixaBank" },
                    { 8, "Fabricante de automóviles con sede en Martorell.", "Autovía A-2, Km 585, 08760 Martorell, Barcelona", "https://example.com/seat.png", "Seat" },
                    { 9, "Gestión de aeropuertos en España y en el mundo.", "Calle Peonías, 12, 28042 Madrid", "https://example.com/aena.png", "Aena" },
                    { 10, "Empresa global de infraestructuras y servicios.", "Calle Príncipe de Vergara, 135, 28002 Madrid", "https://example.com/ferrovial.png", "Ferrovial" },
                    { 11, "Compañía de seguros global.", "Carretera de Pozuelo, 52, 28220 Majadahonda, Madrid", "https://example.com/mapfre.png", "Mapfre" },
                    { 12, "Líder en energías renovables y construcción sostenible.", "Avenida de Europa, 18, 28108 Alcobendas, Madrid", "https://example.com/acciona.png", "Acciona" }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "IdEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[,]
                {
                    { 13, "Multinacional de banca y servicios financieros.", "Calle Azul, 4, 28050 Madrid", "https://example.com/bbva.png", "BBVA" },
                    { 14, "Proveedor líder de tecnología en la industria del viaje.", "Calle Salvador de Madariaga, 1, 28027 Madrid", "https://example.com/amadeus.png", "Amadeus" },
                    { 15, "Líder global en el sector de los hemoderivados.", "Calle Jesús i Maria, 6, 08022 Barcelona", "https://example.com/grifols.png", "Grifols" },
                    { 30, "Una de las mayores marcas de moda del mundo.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://example.com/zara.png", "Zara" }
                });

            migrationBuilder.InsertData(
                table: "EmpresasCiudades",
                columns: new[] { "IdEmpresaCiudad", "IdCiudad", "IdEmpresa" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 3, 3 },
                    { 5, 4, 4 },
                    { 6, 3, 5 },
                    { 7, 3, 6 },
                    { 8, 2, 6 },
                    { 9, 2, 7 },
                    { 10, 2, 8 },
                    { 11, 3, 9 },
                    { 12, 3, 10 },
                    { 13, 3, 11 },
                    { 14, 3, 12 },
                    { 15, 3, 13 },
                    { 16, 3, 14 },
                    { 17, 2, 15 },
                    { 18, 1, 30 },
                    { 19, 2, 30 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "EmpresasCiudades",
                keyColumn: "IdEmpresaCiudad",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ciudadades",
                keyColumn: "IdCiudad",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 30);
        }
    }
}

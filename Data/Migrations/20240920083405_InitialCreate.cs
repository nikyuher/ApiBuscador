using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Ciudadades",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudadades", x => x.IdCiudad);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaCategorias",
                columns: table => new
                {
                    IdEmpresaCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaCategorias", x => x.IdEmpresaCategoria);
                    table.ForeignKey(
                        name: "FK_EmpresaCategorias_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaCategorias_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasCiudades",
                columns: table => new
                {
                    IdEmpresaCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCiudad = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasCiudades", x => x.IdEmpresaCiudad);
                    table.ForeignKey(
                        name: "FK_EmpresasCiudades_Ciudadades_IdCiudad",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudadades",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresasCiudades_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, "Líder mundial en distribución de moda.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://ik.imagekit.io/Mariocanizares/Empresas/inditexLC.jpg?updatedAt=1726649179851", "Inditex" },
                    { 2, "Una de las mayores entidades bancarias del mundo.", "Ciudad Grupo Santander, 28660 Boadilla del Monte, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/santander.jpg?updatedAt=1726649877238", "Banco Santander" },
                    { 3, "Multinacional española de telecomunicaciones.", "Distrito Telefónica, 28050 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/telefonica.jpg?updatedAt=1726649877081", "Telefónica" },
                    { 4, "Una de las mayores empresas energéticas del mundo.", "Plaza Euskadi 5, 48009 Bilbao", "https://ik.imagekit.io/Mariocanizares/Empresas/iberdrola-.jpg?updatedAt=1726649877427", "Iberdrola" },
                    { 5, "Empresa energética multinacional española.", "Calle Méndez Álvaro, 44, 28045 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458", "Repsol" },
                    { 6, "Cadena de grandes almacenes más grande de Europa.", "Calle Hermosilla, 112, 28009 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/elcorteingles.jpeg?updatedAt=1726649879087", "El Corte Inglés" },
                    { 7, "Uno de los bancos más importantes de España.", "Av. Diagonal, 621, 08028 Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/caixabanck.jpg?updatedAt=1726649879170", "CaixaBank" },
                    { 8, "Fabricante de automóviles con sede en Martorell.", "Autovía A-2, Km 585, 08760 Martorell, Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/seat.jpg?updatedAt=1726649876969", "Seat" },
                    { 9, "Gestión de aeropuertos en España y en el mundo.", "Calle Peonías, 12, 28042 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/aena-aeropuerto.jpg?updatedAt=1726649877286", "Aena" },
                    { 10, "Empresa global de infraestructuras y servicios.", "Calle Príncipe de Vergara, 135, 28002 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpeg?updatedAt=1726649879406", "Ferrovial" },
                    { 11, "Compañía de seguros global.", "Carretera de Pozuelo, 52, 28220 Majadahonda, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/mafre.jpg?updatedAt=1726649877454", "Mapfre" },
                    { 12, "Líder en energías renovables y construcción sostenible.", "Avenida de Europa, 18, 28108 Alcobendas, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/acciona.webp?updatedAt=1726649877393", "Acciona" }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "IdEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[,]
                {
                    { 13, "Multinacional de banca y servicios financieros.", "Calle Azul, 4, 28050 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/BBVA.jpg?updatedAt=1726649879175", "BBVA" },
                    { 14, "Proveedor líder de tecnología en la industria del viaje.", "Calle Salvador de Madariaga, 1, 28027 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/amadeus.jpg?updatedAt=1726649879691", "Amadeus" },
                    { 15, "Líder global en el sector de los hemoderivados.", "Calle Jesús i Maria, 6, 08022 Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/grifols.jpg?updatedAt=1726649877212", "Grifols" },
                    { 16, "Una de las mayores marcas de moda del mundo.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://ik.imagekit.io/Mariocanizares/Empresas/zara.jpg?updatedAt=1726649877219", "Zara" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCategorias_IdCategoria",
                table: "EmpresaCategorias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCategorias_IdEmpresa",
                table: "EmpresaCategorias",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasCiudades_IdCiudad",
                table: "EmpresasCiudades",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasCiudades_IdEmpresa",
                table: "EmpresasCiudades",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaCategorias");

            migrationBuilder.DropTable(
                name: "EmpresasCiudades");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Ciudadades");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}

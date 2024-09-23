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
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { 1, "Moda" },
                    { 2, "Banca" },
                    { 3, "Telecomunicaciones" },
                    { 4, "Energía" },
                    { 5, "Distribución" },
                    { 6, "Automotriz" },
                    { 7, "Infraestructura" },
                    { 8, "Seguros" },
                    { 9, "Tecnología" },
                    { 10, "Hotelería" },
                    { 11, "Transporte" },
                    { 12, "Alimentación" },
                    { 13, "Farmacéutica" },
                    { 14, "Inmobiliaria" },
                    { 15, "Seguridad" },
                    { 16, "Construcción" },
                    { 17, "Logística" }
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
                    { 25, "Segovia" }
                });

            migrationBuilder.InsertData(
                table: "Ciudadades",
                columns: new[] { "IdCiudad", "Nombre" },
                values: new object[,]
                {
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
                    { 12, "Líder en energías renovables y construcción sostenible.", "Avenida de Europa, 18, 28108 Alcobendas, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/acciona.webp?updatedAt=1726649877393", "Acciona" },
                    { 13, "Multinacional de banca y servicios financieros.", "Calle Azul, 4, 28050 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/BBVA.jpg?updatedAt=1726649879175", "BBVA" },
                    { 14, "Proveedor líder de tecnología en la industria del viaje.", "Calle Salvador de Madariaga, 1, 28027 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/amadeus.jpg?updatedAt=1726649879691", "Amadeus" },
                    { 15, "Líder global en el sector de los hemoderivados.", "Calle Jesús i Maria, 6, 08022 Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/grifols.jpg?updatedAt=1726649877212", "Grifols" },
                    { 16, "Una de las mayores marcas de moda del mundo.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://ik.imagekit.io/Mariocanizares/Empresas/zara.jpg?updatedAt=1726649877219", "Zara" },
                    { 17, "Cadena de supermercados líder en España.", "Calle Valencia, 5, 46016 Tavernes Blanques, Valencia", "https://ik.imagekit.io/Mariocanizares/Empresas/mercadona.jpg?updatedAt=1726649879213", "Mercadona" },
                    { 18, "Cadena de hoteles con presencia internacional.", "Calle Gremio Toneleros, 24, 07009 Palma, Islas Baleares", "https://ik.imagekit.io/Mariocanizares/Empresas/meliahotels.jpg?updatedAt=1726649879218", "Meliá Hotels" },
                    { 19, "Empresa multinacional de gas y electricidad.", "Avenida de América, 38, 28028 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/naturgy.jpg?updatedAt=1726649879220", "Naturgy" },
                    { 20, "Empresa de construcción y servicios.", "Calle Federico Salmón, 13, 28016 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/fcc.jpg?updatedAt=1726649879225", "FCC" },
                    { 21, "Multinacional en construcción e infraestructuras.", "Calle Condesa de Venadito, 7, 28027 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/sacyr.jpg?updatedAt=1726649879229", "Sacyr" },
                    { 22, "Operador europeo de infraestructuras de telecomunicaciones.", "Calle Juan Esplandiú, 11, 28007 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/cellnex.jpg?updatedAt=1726649879231", "Cellnex" },
                    { 23, "Grupo turístico líder en España.", "Calle de la Cruz, 1, 28760 Tres Cantos, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/globalia.jpg?updatedAt=1726649879233", "Globalia" },
                    { 24, "Líder mundial en envolturas alimentarias.", "Polígono Industrial Berroa, 15, 31192 Tajonar, Navarra", "https://ik.imagekit.io/Mariocanizares/Empresas/viscofan.jpg?updatedAt=1726649879236", "Viscofan" },
                    { 25, "Multinacional de energía.", "Torre Cepsa, Paseo de la Castellana, 259A, 28046 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/cepsa.jpg?updatedAt=1726649879240", "Cepsa" },
                    { 26, "Empresa líder en seguridad privada.", "Calle Pajaritos, 24, 28007 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/prosegur.jpg?updatedAt=1726649879245", "Prosegur" },
                    { 27, "Multinacional de consultoría y tecnología.", "Avenida de Bruselas, 35, 28108 Alcobendas, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/indra.jpg?updatedAt=1726649879249", "Indra" },
                    { 28, "Empresa líder en el sector inmobiliario.", "Paseo de la Castellana, 163, 28046 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/colonial.jpg?updatedAt=1726649879252", "Colonial" },
                    { 29, "Cadena hotelera con presencia internacional.", "Calle Santa Engracia, 120, 28003 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/nhhotelgroup.jpg?updatedAt=1726649879256", "NH Hotel Group" },
                    { 30, "Líder en el sector alimentario.", "Calle del Prado, 6, 28014 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ebrofoods.jpg?updatedAt=1726649879261", "Ebro Foods" },
                    { 31, "Compañía farmacéutica internacional.", "Ronda General Mitre, 151, 08022 Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/almirall.jpg?updatedAt=1726649879266", "Almirall" },
                    { 32, "Empresa farmacéutica especializada en productos inyectables.", "Calle Julián Camarillo, 35, 28037 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/rovi.jpg?updatedAt=1726649879270", "Rovi" },
                    { 33, "Operador líder en transporte de pasajeros.", "Calle Miguel Fleta, 4, 28037 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/alsa.jpg?updatedAt=1726649879275", "Alsa" },
                    { 34, "Multinacional de productos de colágeno y envolturas.", "Polígono Berroa, 15, 31192 Tajonar, Navarra", "https://ik.imagekit.io/Mariocanizares/Empresas/viscofan.jpg?updatedAt=1726649879279", "Viscofan" },
                    { 35, "Empresa farmacéutica especializada en productos oncológicos.", "Avenida de los Reyes, 1, 28760 Tres Cantos, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/pharmamar.jpg?updatedAt=1726649879283", "Pharmamar" },
                    { 36, "Distribuidora líder en el sur de Europa.", "Avenida de la Vega, 1, 28108 Alcobendas, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/logista.jpg?updatedAt=1726649879286", "Logista" }
                });

            migrationBuilder.InsertData(
                table: "EmpresaCategorias",
                columns: new[] { "IdEmpresaCategoria", "IdCategoria", "IdEmpresa" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 4, 5 },
                    { 6, 5, 6 },
                    { 7, 2, 7 },
                    { 8, 6, 8 },
                    { 9, 11, 9 },
                    { 10, 7, 10 },
                    { 11, 8, 11 },
                    { 12, 7, 12 },
                    { 13, 2, 13 },
                    { 14, 9, 14 },
                    { 15, 13, 15 },
                    { 16, 1, 16 },
                    { 17, 12, 17 },
                    { 18, 10, 18 },
                    { 19, 4, 19 },
                    { 20, 16, 20 },
                    { 21, 16, 21 },
                    { 22, 3, 22 },
                    { 23, 9, 23 },
                    { 24, 12, 24 },
                    { 25, 4, 25 },
                    { 26, 15, 26 },
                    { 27, 9, 27 },
                    { 28, 14, 28 },
                    { 29, 10, 29 },
                    { 30, 12, 30 },
                    { 31, 13, 31 },
                    { 32, 13, 32 },
                    { 33, 11, 33 },
                    { 34, 12, 34 },
                    { 35, 13, 35 },
                    { 36, 17, 36 }
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
                    { 6, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "EmpresasCiudades",
                columns: new[] { "IdEmpresaCiudad", "IdCiudad", "IdEmpresa" },
                values: new object[,]
                {
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
                    { 18, 1, 16 },
                    { 19, 2, 16 },
                    { 20, 2, 17 },
                    { 21, 2, 18 },
                    { 22, 3, 19 },
                    { 23, 3, 20 },
                    { 24, 3, 21 },
                    { 25, 3, 22 },
                    { 26, 2, 23 },
                    { 27, 1, 24 },
                    { 28, 3, 25 },
                    { 29, 3, 26 },
                    { 30, 3, 27 },
                    { 31, 3, 28 },
                    { 32, 3, 29 },
                    { 33, 3, 30 },
                    { 34, 2, 31 },
                    { 35, 3, 32 },
                    { 36, 3, 33 },
                    { 37, 3, 34 },
                    { 38, 3, 35 },
                    { 39, 3, 36 },
                    { 40, 1, 15 },
                    { 41, 1, 18 },
                    { 42, 1, 26 },
                    { 43, 1, 29 },
                    { 44, 2, 10 },
                    { 45, 4, 12 },
                    { 46, 4, 19 },
                    { 47, 2, 9 },
                    { 48, 3, 1 }
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

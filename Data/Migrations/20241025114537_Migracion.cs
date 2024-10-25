using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ciudadades",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudadades", x => x.IdCiudad);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                columns: table => new
                {
                    IdSuscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoPlan = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.IdSuscripcion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contrasena = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rol = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordResetCode = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordResetCodeExpiry = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PasswordChangedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Peticiones",
                columns: table => new
                {
                    IdPeticion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEmpresa = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescripcionEmpresa = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DireccionEmpresa = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagenEmpresaURL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCategoriaEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdCiudadEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peticiones", x => x.IdPeticion);
                    table.ForeignKey(
                        name: "FK_Peticiones_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioSuscripciones",
                columns: table => new
                {
                    IdUsuarioSuscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    SuscripcionId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DuracionMeses = table.Column<int>(type: "int", nullable: false),
                    EsActiva = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSuscripciones", x => x.IdUsuarioSuscripcion);
                    table.ForeignKey(
                        name: "FK_UsuarioSuscripciones_Suscripciones_SuscripcionId",
                        column: x => x.SuscripcionId,
                        principalTable: "Suscripciones",
                        principalColumn: "IdSuscripcion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioSuscripciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    CorreoEmpresa = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SitioWeb = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagen = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PeticionIdPeticion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_Empresas_Peticiones_PeticionIdPeticion",
                        column: x => x.PeticionIdPeticion,
                        principalTable: "Peticiones",
                        principalColumn: "IdPeticion");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmpresaCategorias",
                columns: table => new
                {
                    IdEmpresaCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmpresasCiudades",
                columns: table => new
                {
                    IdEmpresaCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioEmpresas",
                columns: table => new
                {
                    IdUsuarioEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    { 25, "Segovia" },
                    { 26, "Soria" },
                    { 27, "Badajoz" },
                    { 28, "Cáceres" },
                    { 29, "Logroño" },
                    { 30, "Pamplona" }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "IdEmpresa", "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "PeticionIdPeticion", "SitioWeb", "Telefono" },
                values: new object[,]
                {
                    { 1, "contacto@inditex.com", "Líder mundial en distribución de moda.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://ik.imagekit.io/Mariocanizares/Empresas/inditexLC.jpg?updatedAt=1726649179851", "Inditex", null, "https://www.inditex.com", 981123456 },
                    { 2, "contacto@santander.com", "Una de las mayores entidades bancarias del mundo.", "Ciudad Grupo Santander, 28660 Boadilla del Monte, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/santander.jpg?updatedAt=1726649877238", "Banco Santander", null, "https://www.bancosantander.es", 915123456 },
                    { 3, "info@telefonica.com", "Multinacional española de telecomunicaciones.", "Distrito Telefónica, 28050 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/telefonica.jpg?updatedAt=1726649877081", "Telefónica", null, "https://www.telefonica.com", 914123456 },
                    { 4, "contacto@iberdrola.com", "Una de las mayores empresas energéticas del mundo.", "Plaza Euskadi 5, 48009 Bilbao", "https://ik.imagekit.io/Mariocanizares/Empresas/iberdrola-.jpg?updatedAt=1726649877427", "Iberdrola", null, "https://www.iberdrola.com", 944123456 },
                    { 5, "info@repsol.com", "Empresa energética multinacional española.", "Calle Méndez Álvaro, 44, 28045 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458", "Repsol", null, "https://www.repsol.com", 915678910 },
                    { 6, "atencioncliente@elcorteingles.es", "Cadena de grandes almacenes más grande de Europa.", "Calle Hermosilla, 112, 28009 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/elcorteingles.jpeg?updatedAt=1726649879087", "El Corte Inglés", null, "https://www.elcorteingles.es", 917123456 },
                    { 7, "info@caixabank.com", "Uno de los bancos más importantes de España.", "Av. Diagonal, 621, 08028 Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/caixabanck.jpg?updatedAt=1726649879170", "CaixaBank", null, "https://www.caixabank.es", 936123456 },
                    { 8, "contacto@seat.com", "Fabricante de automóviles con sede en Martorell.", "Autovía A-2, Km 585, 08760 Martorell, Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/seat.jpg?updatedAt=1726649876969", "Seat", null, "https://www.seat.com", 936123456 },
                    { 9, "info@aena.es", "Gestión de aeropuertos en España y en el mundo.", "Calle Peonías, 12, 28042 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/aena-aeropuerto.jpg?updatedAt=1726649877286", "Aena", null, "https://www.aena.es", 915678910 },
                    { 10, "contacto@ferrovial.com", "Empresa global de infraestructuras y servicios.", "Calle Príncipe de Vergara, 135, 28002 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpeg?updatedAt=1726649879406", "Ferrovial", null, "https://www.ferrovial.com", 915678910 },
                    { 11, "info@mapfre.com", "Compañía de seguros global.", "Carretera de Pozuelo, 52, 28220 Majadahonda, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/mafre.jpg?updatedAt=1726649877454", "Mapfre", null, "https://www.mapfre.com", 914123456 },
                    { 12, "contacto@acciona.com", "Líder en energías renovables y construcción sostenible.", "Avenida de Europa, 18, 28108 Alcobendas, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/acciona.webp?updatedAt=1726649877393", "Acciona", null, "https://www.acciona.com", 916123456 },
                    { 13, "atencioncliente@bbva.com", "Multinacional de banca y servicios financieros.", "Calle Azul, 4, 28050 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/BBVA.jpg?updatedAt=1726649879175", "BBVA", null, "https://www.bbva.es", 917123456 },
                    { 14, "contacto@amadeus.com", "Proveedor líder de tecnología en la industria del viaje.", "Calle Salvador de Madariaga, 1, 28027 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/amadeus.jpg?updatedAt=1726649879691", "Amadeus", null, "https://www.amadeus.com", 917123456 },
                    { 15, "info@grifols.com", "Líder global en el sector de los hemoderivados.", "Calle Jesús i Maria, 6, 08022 Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/grifols.jpg?updatedAt=1726649877212", "Grifols", null, "https://www.grifols.com", 932123456 },
                    { 16, "contacto@zara.com", "Una de las mayores marcas de moda del mundo.", "Av. de la Diputación, 15142 Arteijo, La Coruña", "https://ik.imagekit.io/Mariocanizares/Empresas/zara.jpg?updatedAt=1726649877219", "Zara", null, "https://www.zara.com", 981123456 },
                    { 17, "atencioncliente@mercadona.es", "Cadena de supermercados líder en España.", "Calle Valencia, 5, 46016 Tavernes Blanques, Valencia", "https://ik.imagekit.io/Mariocanizares/Empresas/mercadona.jpg?updatedAt=1726649879213", "Mercadona", null, "https://www.mercadona.es", 961123456 },
                    { 18, "contacto@repsol.com", "Multinacional energética con operaciones en 30 países.", "Calle Méndez Álvaro, 44, 28045 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458", "Repsol", null, "https://www.repsol.com", 915678910 },
                    { 19, "info@orange.es", "Compañía multinacional de telecomunicaciones.", "Calle Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/orange.jpg?updatedAt=1726649877392", "Orange", null, "https://www.orange.es", 912123456 },
                    { 20, "info@vodafone.es", "Proveedor global de telecomunicaciones.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/vodafone.jpg?updatedAt=1726649877234", "Vodafone", null, "https://www.vodafone.es", 912123456 },
                    { 21, "info@nh-hotels.com", "Cadena de hoteles internacional.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/nh.jpg?updatedAt=1726649877215", "NH Hotel Group", null, "https://www.nh-hotels.com", 917123456 },
                    { 22, "contacto@accenture.com", "Consultora de gestión y tecnología.", "Calle Príncipe de Vergara, 1, 28001 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/accenture.jpg?updatedAt=1726649877216", "Accenture", null, "https://www.accenture.com", 917123456 },
                    { 23, "info@capgemini.com", "Consultora de servicios de tecnología y outsourcing.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/capgemini.jpg?updatedAt=1726649877287", "Capgemini", null, "https://www.capgemini.com", 912123456 },
                    { 24, "info@everis.com", "Consultoría y outsourcing de TI.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/everis.jpg?updatedAt=1726649877241", "Everis", null, "https://www.everis.com", 917123456 },
                    { 25, "contacto@grupoantolin.com", "Fabricante de componentes para el sector automotriz.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/grupoantolin.jpg?updatedAt=1726649877217", "Grupo Antolin", null, "https://www.grupoantolin.com", 912123456 },
                    { 26, "info@sacyr.com", "Grupo líder en construcción e ingeniería.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/sacyr.jpg?updatedAt=1726649877261", "Sacyr", null, "https://www.sacyr.com", 917123456 },
                    { 27, "info@ferrovial.com", "Empresa global de infraestructuras y servicios.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpg?updatedAt=1726649877240", "Ferrovial", null, "https://www.ferrovial.com", 912123456 },
                    { 28, "contacto@boeing.com", "Fabricante de aviones y tecnología aeroespacial.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/boeing.jpg?updatedAt=1726649877218", "Boeing", null, "https://www.boeing.com", 912123456 },
                    { 29, "info@ge.com", "Conglomerado industrial de energía y tecnología.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ge.jpg?updatedAt=1726649877254", "General Electric", null, "https://www.ge.com", 912123456 },
                    { 30, "info@siemens.com", "Multinacional de tecnología e ingeniería.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/siemens.jpg?updatedAt=1726649877467", "Siemens", null, "https://www.siemens.com", 912123456 },
                    { 31, "info@bosch.com", "Multinacional alemana de ingeniería y tecnología.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/bosch.jpg?updatedAt=1726649877236", "Bosch", null, "https://www.bosch.com", 912123456 },
                    { 32, "info@honda.com", "Fabricante de automóviles y motocicletas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/honda.jpg?updatedAt=1726649877452", "Honda", null, "https://www.honda.com", 912123456 },
                    { 33, "contacto@coca-cola.com", "Multinacional de bebidas no alcohólicas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/coca-cola.jpg?updatedAt=1726649877492", "Coca-Cola", null, "https://www.coca-cola.com", 912123456 },
                    { 34, "info@pepsi.com", "Compañía de bebidas no alcohólicas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/pepsi.jpg?updatedAt=1726649877214", "Pepsi", null, "https://www.pepsi.com", 912123456 },
                    { 35, "contacto@nestle.com", "Líder mundial en alimentos y bebidas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/nestle.jpg?updatedAt=1726649877248", "Nestlé", null, "https://www.nestle.com", 912123456 },
                    { 36, "info@danone.com", "Compañía multinacional de productos lácteos.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/danone.jpg?updatedAt=1726649877223", "Danone", null, "https://www.danone.com", 912123456 }
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
                name: "IX_Empresas_PeticionIdPeticion",
                table: "Empresas",
                column: "PeticionIdPeticion");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasCiudades_IdCiudad",
                table: "EmpresasCiudades",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasCiudades_IdEmpresa",
                table: "EmpresasCiudades",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Peticiones_IdUsuario",
                table: "Peticiones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresas_IdEmpresa",
                table: "UsuarioEmpresas",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresas_IdUsuario",
                table: "UsuarioEmpresas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSuscripciones_SuscripcionId",
                table: "UsuarioSuscripciones",
                column: "SuscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSuscripciones_UsuarioId",
                table: "UsuarioSuscripciones",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaCategorias");

            migrationBuilder.DropTable(
                name: "EmpresasCiudades");

            migrationBuilder.DropTable(
                name: "UsuarioEmpresas");

            migrationBuilder.DropTable(
                name: "UsuarioSuscripciones");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Ciudadades");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Suscripciones");

            migrationBuilder.DropTable(
                name: "Peticiones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

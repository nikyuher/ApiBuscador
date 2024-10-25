using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buscador.Data.Migrations
{
    public partial class Suscripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorreoEmpresa",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SitioWeb",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                columns: table => new
                {
                    IdSuscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.IdSuscripcion);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSuscripciones",
                columns: table => new
                {
                    IdUsuarioSuscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    SuscripcionId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracionMeses = table.Column<int>(type: "int", nullable: false),
                    EsActiva = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 1,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@inditex.com", "https://www.inditex.com", 981123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 2,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@santander.com", "https://www.bancosantander.es", 915123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 3,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "info@telefonica.com", "https://www.telefonica.com", 914123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 4,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@iberdrola.com", "https://www.iberdrola.com", 944123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 5,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "info@repsol.com", "https://www.repsol.com", 915678910 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 6,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "atencioncliente@elcorteingles.es", "https://www.elcorteingles.es", 917123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 7,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "info@caixabank.com", "https://www.caixabank.es", 936123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 8,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@seat.com", "https://www.seat.com", 936123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 9,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "info@aena.es", "https://www.aena.es", 915678910 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 10,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@ferrovial.com", "https://www.ferrovial.com", 915678910 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 11,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "info@mapfre.com", "https://www.mapfre.com", 914123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 12,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@acciona.com", "https://www.acciona.com", 916123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 13,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "atencioncliente@bbva.com", "https://www.bbva.es", 917123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 14,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@amadeus.com", "https://www.amadeus.com", 917123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 15,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "info@grifols.com", "https://www.grifols.com", 932123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 16,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@zara.com", "https://www.zara.com", 981123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 17,
                columns: new[] { "CorreoEmpresa", "SitioWeb", "Telefono" },
                values: new object[] { "atencioncliente@mercadona.es", "https://www.mercadona.es", 961123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 18,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@repsol.com", "Multinacional energética con operaciones en 30 países.", "Calle Méndez Álvaro, 44, 28045 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458", "Repsol", "https://www.repsol.com", 915678910 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 19,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@orange.es", "Compañía multinacional de telecomunicaciones.", "Calle Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/orange.jpg?updatedAt=1726649877392", "Orange", "https://www.orange.es", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 20,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@vodafone.es", "Proveedor global de telecomunicaciones.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/vodafone.jpg?updatedAt=1726649877234", "Vodafone", "https://www.vodafone.es", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 21,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@nh-hotels.com", "Cadena de hoteles internacional.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/nh.jpg?updatedAt=1726649877215", "NH Hotel Group", "https://www.nh-hotels.com", 917123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 22,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@accenture.com", "Consultora de gestión y tecnología.", "Calle Príncipe de Vergara, 1, 28001 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/accenture.jpg?updatedAt=1726649877216", "Accenture", "https://www.accenture.com", 917123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 23,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@capgemini.com", "Consultora de servicios de tecnología y outsourcing.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/capgemini.jpg?updatedAt=1726649877287", "Capgemini", "https://www.capgemini.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 24,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@everis.com", "Consultoría y outsourcing de TI.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/everis.jpg?updatedAt=1726649877241", "Everis", "https://www.everis.com", 917123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 25,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@grupoantolin.com", "Fabricante de componentes para el sector automotriz.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/grupoantolin.jpg?updatedAt=1726649877217", "Grupo Antolin", "https://www.grupoantolin.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 26,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@sacyr.com", "Grupo líder en construcción e ingeniería.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/sacyr.jpg?updatedAt=1726649877261", "Sacyr", "https://www.sacyr.com", 917123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 27,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@ferrovial.com", "Empresa global de infraestructuras y servicios.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpg?updatedAt=1726649877240", "Ferrovial", "https://www.ferrovial.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 28,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@boeing.com", "Fabricante de aviones y tecnología aeroespacial.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/boeing.jpg?updatedAt=1726649877218", "Boeing", "https://www.boeing.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 29,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@ge.com", "Conglomerado industrial de energía y tecnología.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ge.jpg?updatedAt=1726649877254", "General Electric", "https://www.ge.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 30,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@siemens.com", "Multinacional de tecnología e ingeniería.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/siemens.jpg?updatedAt=1726649877467", "Siemens", "https://www.siemens.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 31,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@bosch.com", "Multinacional alemana de ingeniería y tecnología.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/bosch.jpg?updatedAt=1726649877236", "Bosch", "https://www.bosch.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 32,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@honda.com", "Fabricante de automóviles y motocicletas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/honda.jpg?updatedAt=1726649877452", "Honda", "https://www.honda.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 33,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@coca-cola.com", "Multinacional de bebidas no alcohólicas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/coca-cola.jpg?updatedAt=1726649877492", "Coca-Cola", "https://www.coca-cola.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 34,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@pepsi.com", "Compañía de bebidas no alcohólicas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/pepsi.jpg?updatedAt=1726649877214", "Pepsi", "https://www.pepsi.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 35,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "contacto@nestle.com", "Líder mundial en alimentos y bebidas.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/nestle.jpg?updatedAt=1726649877248", "Nestlé", "https://www.nestle.com", 912123456 });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 36,
                columns: new[] { "CorreoEmpresa", "Descripcion", "Direccion", "Imagen", "Nombre", "SitioWeb", "Telefono" },
                values: new object[] { "info@danone.com", "Compañía multinacional de productos lácteos.", "Calle de Vallehermoso, 79, 28015 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/danone.jpg?updatedAt=1726649877223", "Danone", "https://www.danone.com", 912123456 });

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
                name: "UsuarioSuscripciones");

            migrationBuilder.DropTable(
                name: "Suscripciones");

            migrationBuilder.DropColumn(
                name: "CorreoEmpresa",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "SitioWeb",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Empresas");

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 18,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Cadena de hoteles con presencia internacional.", "Calle Gremio Toneleros, 24, 07009 Palma, Islas Baleares", "https://ik.imagekit.io/Mariocanizares/Empresas/meliahotels.jpg?updatedAt=1726649879218", "Meliá Hotels" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 19,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Empresa multinacional de gas y electricidad.", "Avenida de América, 38, 28028 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/naturgy.jpg?updatedAt=1726649879220", "Naturgy" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 20,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Empresa de construcción y servicios.", "Calle Federico Salmón, 13, 28016 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/fcc.jpg?updatedAt=1726649879225", "FCC" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 21,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Multinacional en construcción e infraestructuras.", "Calle Condesa de Venadito, 7, 28027 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/sacyr.jpg?updatedAt=1726649879229", "Sacyr" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 22,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Operador europeo de infraestructuras de telecomunicaciones.", "Calle Juan Esplandiú, 11, 28007 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/cellnex.jpg?updatedAt=1726649879231", "Cellnex" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 23,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Grupo turístico líder en España.", "Calle de la Cruz, 1, 28760 Tres Cantos, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/globalia.jpg?updatedAt=1726649879233", "Globalia" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 24,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Líder mundial en envolturas alimentarias.", "Polígono Industrial Berroa, 15, 31192 Tajonar, Navarra", "https://ik.imagekit.io/Mariocanizares/Empresas/viscofan.jpg?updatedAt=1726649879236", "Viscofan" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 25,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Multinacional de energía.", "Torre Cepsa, Paseo de la Castellana, 259A, 28046 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/cepsa.jpg?updatedAt=1726649879240", "Cepsa" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 26,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Empresa líder en seguridad privada.", "Calle Pajaritos, 24, 28007 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/prosegur.jpg?updatedAt=1726649879245", "Prosegur" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 27,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Multinacional de consultoría y tecnología.", "Avenida de Bruselas, 35, 28108 Alcobendas, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/indra.jpg?updatedAt=1726649879249", "Indra" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 28,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Empresa líder en el sector inmobiliario.", "Paseo de la Castellana, 163, 28046 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/colonial.jpg?updatedAt=1726649879252", "Colonial" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 29,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Cadena hotelera con presencia internacional.", "Calle Santa Engracia, 120, 28003 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/nhhotelgroup.jpg?updatedAt=1726649879256", "NH Hotel Group" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 30,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Líder en el sector alimentario.", "Calle del Prado, 6, 28014 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/ebrofoods.jpg?updatedAt=1726649879261", "Ebro Foods" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 31,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Compañía farmacéutica internacional.", "Ronda General Mitre, 151, 08022 Barcelona", "https://ik.imagekit.io/Mariocanizares/Empresas/almirall.jpg?updatedAt=1726649879266", "Almirall" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 32,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Empresa farmacéutica especializada en productos inyectables.", "Calle Julián Camarillo, 35, 28037 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/rovi.jpg?updatedAt=1726649879270", "Rovi" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 33,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Operador líder en transporte de pasajeros.", "Calle Miguel Fleta, 4, 28037 Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/alsa.jpg?updatedAt=1726649879275", "Alsa" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 34,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Multinacional de productos de colágeno y envolturas.", "Polígono Berroa, 15, 31192 Tajonar, Navarra", "https://ik.imagekit.io/Mariocanizares/Empresas/viscofan.jpg?updatedAt=1726649879279", "Viscofan" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 35,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Empresa farmacéutica especializada en productos oncológicos.", "Avenida de los Reyes, 1, 28760 Tres Cantos, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/pharmamar.jpg?updatedAt=1726649879283", "Pharmamar" });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "IdEmpresa",
                keyValue: 36,
                columns: new[] { "Descripcion", "Direccion", "Imagen", "Nombre" },
                values: new object[] { "Distribuidora líder en el sur de Europa.", "Avenida de la Vega, 1, 28108 Alcobendas, Madrid", "https://ik.imagekit.io/Mariocanizares/Empresas/logista.jpg?updatedAt=1726649879286", "Logista" });
        }
    }
}

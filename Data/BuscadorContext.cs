namespace Buscador.Data;

using Microsoft.EntityFrameworkCore;
using Buscador.Models;

public class BuscadorContext : DbContext
{

    public BuscadorContext(DbContextOptions<BuscadorContext> options)
    : base(options)
    { }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Peticion>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Peticiones)
            .HasForeignKey(p => p.IdUsuario);

        modelBuilder.Entity<UsuarioSuscripcion>()
            .HasKey(us => us.IdUsuarioSuscripcion);

        modelBuilder.Entity<UsuarioSuscripcion>()
            .HasOne(us => us.Usuario)
            .WithMany()
            .HasForeignKey(us => us.UsuarioId);

        modelBuilder.Entity<UsuarioSuscripcion>()
            .HasOne(us => us.Suscripcion)
            .WithMany(s => s.UsuarioSuscripciones)
            .HasForeignKey(us => us.SuscripcionId);

        modelBuilder.Entity<EmpresaCategoria>()
                        .HasOne(ec => ec.Empresa)
                        .WithMany(e => e.EmpresaCategorias)
                        .HasForeignKey(ec => ec.IdEmpresa);

        modelBuilder.Entity<EmpresaCategoria>()
            .HasOne(ec => ec.Categoria)
            .WithMany(c => c.EmpresaCategorias)
            .HasForeignKey(ec => ec.IdCategoria);

        modelBuilder.Entity<EmpresaCiudad>()
            .HasOne(ec => ec.Empresa)
            .WithMany(e => e.EmpresasCiudades)
            .HasForeignKey(ec => ec.IdEmpresa);

        modelBuilder.Entity<EmpresaCiudad>()
            .HasOne(ec => ec.Ciudad)
            .WithMany(c => c.EmpresasCiudades)
            .HasForeignKey(ec => ec.IdCiudad);

        modelBuilder.Entity<UsuarioEmpresa>()
                        .HasOne(ue => ue.Usuario)
                        .WithMany(u => u.MisEmpresas)
                        .HasForeignKey(ue => ue.IdUsuario);

        modelBuilder.Entity<UsuarioEmpresa>()
            .HasOne(ue => ue.Empresa)
            .WithMany(e => e.UsuarioEmpresas)
            .HasForeignKey(ue => ue.IdEmpresa);


        modelBuilder.Entity<Ciudad>().HasData(
        new Ciudad { IdCiudad = 1, Nombre = "Madrid" },
        new Ciudad { IdCiudad = 2, Nombre = "Barcelona" },
        new Ciudad { IdCiudad = 3, Nombre = "Valencia" },
        new Ciudad { IdCiudad = 4, Nombre = "Sevilla" },
        new Ciudad { IdCiudad = 5, Nombre = "Zaragoza" },
        new Ciudad { IdCiudad = 6, Nombre = "Málaga" },
        new Ciudad { IdCiudad = 7, Nombre = "Murcia" },
        new Ciudad { IdCiudad = 8, Nombre = "Palma de Mallorca" },
        new Ciudad { IdCiudad = 9, Nombre = "Las Palmas de Gran Canaria" },
        new Ciudad { IdCiudad = 10, Nombre = "Bilbao" },
        new Ciudad { IdCiudad = 11, Nombre = "Alicante" },
        new Ciudad { IdCiudad = 12, Nombre = "Córdoba" },
        new Ciudad { IdCiudad = 13, Nombre = "Valladolid" },
        new Ciudad { IdCiudad = 14, Nombre = "Vigo" },
        new Ciudad { IdCiudad = 15, Nombre = "Gijón" },
        new Ciudad { IdCiudad = 16, Nombre = "Eibar" },
        new Ciudad { IdCiudad = 17, Nombre = "Tarragona" },
        new Ciudad { IdCiudad = 18, Nombre = "Lérida" },
        new Ciudad { IdCiudad = 19, Nombre = "Huelva" },
        new Ciudad { IdCiudad = 20, Nombre = "Granada" },
        new Ciudad { IdCiudad = 21, Nombre = "Jaén" },
        new Ciudad { IdCiudad = 22, Nombre = "Almería" },
        new Ciudad { IdCiudad = 23, Nombre = "Toledo" },
        new Ciudad { IdCiudad = 24, Nombre = "Salamanca" },
        new Ciudad { IdCiudad = 25, Nombre = "Segovia" },
        new Ciudad { IdCiudad = 26, Nombre = "Soria" },
        new Ciudad { IdCiudad = 27, Nombre = "Badajoz" },
        new Ciudad { IdCiudad = 28, Nombre = "Cáceres" },
        new Ciudad { IdCiudad = 29, Nombre = "Logroño" },
        new Ciudad { IdCiudad = 30, Nombre = "Pamplona" }
    );

        modelBuilder.Entity<Categoria>().HasData(
    new Categoria { IdCategoria = 1, Nombre = "Moda" },
    new Categoria { IdCategoria = 2, Nombre = "Banca" },
    new Categoria { IdCategoria = 3, Nombre = "Telecomunicaciones" },
    new Categoria { IdCategoria = 4, Nombre = "Energía" },
    new Categoria { IdCategoria = 5, Nombre = "Distribución" },
    new Categoria { IdCategoria = 6, Nombre = "Automotriz" },
    new Categoria { IdCategoria = 7, Nombre = "Infraestructura" },
    new Categoria { IdCategoria = 8, Nombre = "Seguros" },
    new Categoria { IdCategoria = 9, Nombre = "Tecnología" },
    new Categoria { IdCategoria = 10, Nombre = "Hotelería" },
    new Categoria { IdCategoria = 11, Nombre = "Transporte" },
    new Categoria { IdCategoria = 12, Nombre = "Alimentación" },
    new Categoria { IdCategoria = 13, Nombre = "Farmacéutica" },
    new Categoria { IdCategoria = 14, Nombre = "Inmobiliaria" },
    new Categoria { IdCategoria = 15, Nombre = "Seguridad" },
    new Categoria { IdCategoria = 16, Nombre = "Construcción" },
    new Categoria { IdCategoria = 17, Nombre = "Logística" }
    );

    modelBuilder.Entity<Empresa>().HasData(
    new Empresa { IdEmpresa = 1, Nombre = "Inditex", Descripcion = "Líder mundial en distribución de moda.", Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/inditexLC.jpg?updatedAt=1726649179851", Telefono = 981123456, CorreoEmpresa = "contacto@inditex.com", SitioWeb = "https://www.inditex.com" },
    new Empresa { IdEmpresa = 2, Nombre = "Banco Santander", Descripcion = "Una de las mayores entidades bancarias del mundo.", Direccion = "Ciudad Grupo Santander, 28660 Boadilla del Monte, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/santander.jpg?updatedAt=1726649877238", Telefono = 915123456, CorreoEmpresa = "contacto@santander.com", SitioWeb = "https://www.bancosantander.es" },
    new Empresa { IdEmpresa = 3, Nombre = "Telefónica", Descripcion = "Multinacional española de telecomunicaciones.", Direccion = "Distrito Telefónica, 28050 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/telefonica.jpg?updatedAt=1726649877081", Telefono = 914123456, CorreoEmpresa = "info@telefonica.com", SitioWeb = "https://www.telefonica.com" },
    new Empresa { IdEmpresa = 4, Nombre = "Iberdrola", Descripcion = "Una de las mayores empresas energéticas del mundo.", Direccion = "Plaza Euskadi 5, 48009 Bilbao", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/iberdrola-.jpg?updatedAt=1726649877427", Telefono = 944123456, CorreoEmpresa = "contacto@iberdrola.com", SitioWeb = "https://www.iberdrola.com" },
    new Empresa { IdEmpresa = 5, Nombre = "Repsol", Descripcion = "Empresa energética multinacional española.", Direccion = "Calle Méndez Álvaro, 44, 28045 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458", Telefono = 915678910, CorreoEmpresa = "info@repsol.com", SitioWeb = "https://www.repsol.com" },
    new Empresa { IdEmpresa = 6, Nombre = "El Corte Inglés", Descripcion = "Cadena de grandes almacenes más grande de Europa.", Direccion = "Calle Hermosilla, 112, 28009 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/elcorteingles.jpeg?updatedAt=1726649879087", Telefono = 917123456, CorreoEmpresa = "atencioncliente@elcorteingles.es", SitioWeb = "https://www.elcorteingles.es" },
    new Empresa { IdEmpresa = 7, Nombre = "CaixaBank", Descripcion = "Uno de los bancos más importantes de España.", Direccion = "Av. Diagonal, 621, 08028 Barcelona", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/caixabanck.jpg?updatedAt=1726649879170", Telefono = 936123456, CorreoEmpresa = "info@caixabank.com", SitioWeb = "https://www.caixabank.es" },
    new Empresa { IdEmpresa = 8, Nombre = "Seat", Descripcion = "Fabricante de automóviles con sede en Martorell.", Direccion = "Autovía A-2, Km 585, 08760 Martorell, Barcelona", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/seat.jpg?updatedAt=1726649876969", Telefono = 936123456, CorreoEmpresa = "contacto@seat.com", SitioWeb = "https://www.seat.com" },
    new Empresa { IdEmpresa = 9, Nombre = "Aena", Descripcion = "Gestión de aeropuertos en España y en el mundo.", Direccion = "Calle Peonías, 12, 28042 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/aena-aeropuerto.jpg?updatedAt=1726649877286", Telefono = 915678910, CorreoEmpresa = "info@aena.es", SitioWeb = "https://www.aena.es" },
    new Empresa { IdEmpresa = 10, Nombre = "Ferrovial", Descripcion = "Empresa global de infraestructuras y servicios.", Direccion = "Calle Príncipe de Vergara, 135, 28002 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpeg?updatedAt=1726649879406", Telefono = 915678910, CorreoEmpresa = "contacto@ferrovial.com", SitioWeb = "https://www.ferrovial.com" },
    new Empresa { IdEmpresa = 11, Nombre = "Mapfre", Descripcion = "Compañía de seguros global.", Direccion = "Carretera de Pozuelo, 52, 28220 Majadahonda, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/mafre.jpg?updatedAt=1726649877454", Telefono = 914123456, CorreoEmpresa = "info@mapfre.com", SitioWeb = "https://www.mapfre.com" },
    new Empresa { IdEmpresa = 12, Nombre = "Acciona", Descripcion = "Líder en energías renovables y construcción sostenible.", Direccion = "Avenida de Europa, 18, 28108 Alcobendas, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/acciona.webp?updatedAt=1726649877393", Telefono = 916123456, CorreoEmpresa = "contacto@acciona.com", SitioWeb = "https://www.acciona.com" },
    new Empresa { IdEmpresa = 13, Nombre = "BBVA", Descripcion = "Multinacional de banca y servicios financieros.", Direccion = "Calle Azul, 4, 28050 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/BBVA.jpg?updatedAt=1726649879175", Telefono = 917123456, CorreoEmpresa = "atencioncliente@bbva.com", SitioWeb = "https://www.bbva.es" },
    new Empresa { IdEmpresa = 14, Nombre = "Amadeus", Descripcion = "Proveedor líder de tecnología en la industria del viaje.", Direccion = "Calle Salvador de Madariaga, 1, 28027 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/amadeus.jpg?updatedAt=1726649879691", Telefono = 917123456, CorreoEmpresa = "contacto@amadeus.com", SitioWeb = "https://www.amadeus.com" },
    new Empresa { IdEmpresa = 15, Nombre = "Grifols", Descripcion = "Líder global en el sector de los hemoderivados.", Direccion = "Calle Jesús i Maria, 6, 08022 Barcelona", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/grifols.jpg?updatedAt=1726649877212", Telefono = 932123456, CorreoEmpresa = "info@grifols.com", SitioWeb = "https://www.grifols.com" },
    new Empresa { IdEmpresa = 16, Nombre = "Zara", Descripcion = "Una de las mayores marcas de moda del mundo.", Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/zara.jpg?updatedAt=1726649877219", Telefono = 981123456, CorreoEmpresa = "contacto@zara.com", SitioWeb = "https://www.zara.com" },
    new Empresa { IdEmpresa = 17, Nombre = "Mercadona", Descripcion = "Cadena de supermercados líder en España.", Direccion = "Calle Valencia, 5, 46016 Tavernes Blanques, Valencia", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/mercadona.jpg?updatedAt=1726649879213", Telefono = 961123456, CorreoEmpresa = "atencioncliente@mercadona.es", SitioWeb = "https://www.mercadona.es" },
    new Empresa { IdEmpresa = 18, Nombre = "Repsol", Descripcion = "Multinacional energética con operaciones en 30 países.", Direccion = "Calle Méndez Álvaro, 44, 28045 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458", Telefono = 915678910, CorreoEmpresa = "contacto@repsol.com", SitioWeb = "https://www.repsol.com" },
    new Empresa { IdEmpresa = 19, Nombre = "Orange", Descripcion = "Compañía multinacional de telecomunicaciones.", Direccion = "Calle Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/orange.jpg?updatedAt=1726649877392", Telefono = 912123456, CorreoEmpresa = "info@orange.es", SitioWeb = "https://www.orange.es" },
    new Empresa { IdEmpresa = 20, Nombre = "Vodafone", Descripcion = "Proveedor global de telecomunicaciones.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/vodafone.jpg?updatedAt=1726649877234", Telefono = 912123456, CorreoEmpresa = "info@vodafone.es", SitioWeb = "https://www.vodafone.es" },
    new Empresa { IdEmpresa = 21, Nombre = "NH Hotel Group", Descripcion = "Cadena de hoteles internacional.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/nh.jpg?updatedAt=1726649877215", Telefono = 917123456, CorreoEmpresa = "info@nh-hotels.com", SitioWeb = "https://www.nh-hotels.com" },
    new Empresa { IdEmpresa = 22, Nombre = "Accenture", Descripcion = "Consultora de gestión y tecnología.", Direccion = "Calle Príncipe de Vergara, 1, 28001 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/accenture.jpg?updatedAt=1726649877216", Telefono = 917123456, CorreoEmpresa = "contacto@accenture.com", SitioWeb = "https://www.accenture.com" },
    new Empresa { IdEmpresa = 23, Nombre = "Capgemini", Descripcion = "Consultora de servicios de tecnología y outsourcing.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/capgemini.jpg?updatedAt=1726649877287", Telefono = 912123456, CorreoEmpresa = "info@capgemini.com", SitioWeb = "https://www.capgemini.com" },
    new Empresa { IdEmpresa = 24, Nombre = "Everis", Descripcion = "Consultoría y outsourcing de TI.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/everis.jpg?updatedAt=1726649877241", Telefono = 917123456, CorreoEmpresa = "info@everis.com", SitioWeb = "https://www.everis.com" },
    new Empresa { IdEmpresa = 25, Nombre = "Grupo Antolin", Descripcion = "Fabricante de componentes para el sector automotriz.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/grupoantolin.jpg?updatedAt=1726649877217", Telefono = 912123456, CorreoEmpresa = "contacto@grupoantolin.com", SitioWeb = "https://www.grupoantolin.com" },
    new Empresa { IdEmpresa = 26, Nombre = "Sacyr", Descripcion = "Grupo líder en construcción e ingeniería.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/sacyr.jpg?updatedAt=1726649877261", Telefono = 917123456, CorreoEmpresa = "info@sacyr.com", SitioWeb = "https://www.sacyr.com" },
    new Empresa { IdEmpresa = 27, Nombre = "Ferrovial", Descripcion = "Empresa global de infraestructuras y servicios.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpg?updatedAt=1726649877240", Telefono = 912123456, CorreoEmpresa = "info@ferrovial.com", SitioWeb = "https://www.ferrovial.com" },
    new Empresa { IdEmpresa = 28, Nombre = "Boeing", Descripcion = "Fabricante de aviones y tecnología aeroespacial.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/boeing.jpg?updatedAt=1726649877218", Telefono = 912123456, CorreoEmpresa = "contacto@boeing.com", SitioWeb = "https://www.boeing.com" },
    new Empresa { IdEmpresa = 29, Nombre = "General Electric", Descripcion = "Conglomerado industrial de energía y tecnología.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/ge.jpg?updatedAt=1726649877254", Telefono = 912123456, CorreoEmpresa = "info@ge.com", SitioWeb = "https://www.ge.com" },
    new Empresa { IdEmpresa = 30, Nombre = "Siemens", Descripcion = "Multinacional de tecnología e ingeniería.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/siemens.jpg?updatedAt=1726649877467", Telefono = 912123456, CorreoEmpresa = "info@siemens.com", SitioWeb = "https://www.siemens.com" },
    new Empresa { IdEmpresa = 31, Nombre = "Bosch", Descripcion = "Multinacional alemana de ingeniería y tecnología.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/bosch.jpg?updatedAt=1726649877236", Telefono = 912123456, CorreoEmpresa = "info@bosch.com", SitioWeb = "https://www.bosch.com" },
    new Empresa { IdEmpresa = 32, Nombre = "Honda", Descripcion = "Fabricante de automóviles y motocicletas.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/honda.jpg?updatedAt=1726649877452", Telefono = 912123456, CorreoEmpresa = "info@honda.com", SitioWeb = "https://www.honda.com" },
    new Empresa { IdEmpresa = 33, Nombre = "Coca-Cola", Descripcion = "Multinacional de bebidas no alcohólicas.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/coca-cola.jpg?updatedAt=1726649877492", Telefono = 912123456, CorreoEmpresa = "contacto@coca-cola.com", SitioWeb = "https://www.coca-cola.com" },
    new Empresa { IdEmpresa = 34, Nombre = "Pepsi", Descripcion = "Compañía de bebidas no alcohólicas.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/pepsi.jpg?updatedAt=1726649877214", Telefono = 912123456, CorreoEmpresa = "info@pepsi.com", SitioWeb = "https://www.pepsi.com" },
    new Empresa { IdEmpresa = 35, Nombre = "Nestlé", Descripcion = "Líder mundial en alimentos y bebidas.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/nestle.jpg?updatedAt=1726649877248", Telefono = 912123456, CorreoEmpresa = "contacto@nestle.com", SitioWeb = "https://www.nestle.com" },
    new Empresa { IdEmpresa = 36, Nombre = "Danone", Descripcion = "Compañía multinacional de productos lácteos.", Direccion = "Calle de Vallehermoso, 79, 28015 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/danone.jpg?updatedAt=1726649877223", Telefono = 912123456, CorreoEmpresa = "info@danone.com", SitioWeb = "https://www.danone.com" }
    );


        modelBuilder.Entity<EmpresaCategoria>().HasData(
        new EmpresaCategoria { IdEmpresaCategoria = 1, IdEmpresa = 1, IdCategoria = 1 },  // Inditex - Moda
        new EmpresaCategoria { IdEmpresaCategoria = 2, IdEmpresa = 2, IdCategoria = 2 },  // Banco Santander - Banca
        new EmpresaCategoria { IdEmpresaCategoria = 3, IdEmpresa = 3, IdCategoria = 3 },  // Telefónica - Telecomunicaciones
        new EmpresaCategoria { IdEmpresaCategoria = 4, IdEmpresa = 4, IdCategoria = 4 },  // Iberdrola - Energía
        new EmpresaCategoria { IdEmpresaCategoria = 5, IdEmpresa = 5, IdCategoria = 4 },  // Repsol - Energía
        new EmpresaCategoria { IdEmpresaCategoria = 6, IdEmpresa = 6, IdCategoria = 5 },  // El Corte Inglés - Distribución
        new EmpresaCategoria { IdEmpresaCategoria = 7, IdEmpresa = 7, IdCategoria = 2 },  // CaixaBank - Banca
        new EmpresaCategoria { IdEmpresaCategoria = 8, IdEmpresa = 8, IdCategoria = 6 },  // Seat - Automotriz
        new EmpresaCategoria { IdEmpresaCategoria = 9, IdEmpresa = 9, IdCategoria = 11 }, // Aena - Transporte
        new EmpresaCategoria { IdEmpresaCategoria = 10, IdEmpresa = 10, IdCategoria = 7 }, // Ferrovial - Infraestructura
        new EmpresaCategoria { IdEmpresaCategoria = 11, IdEmpresa = 11, IdCategoria = 8 }, // Mapfre - Seguros
        new EmpresaCategoria { IdEmpresaCategoria = 12, IdEmpresa = 12, IdCategoria = 7 }, // Acciona - Infraestructura
        new EmpresaCategoria { IdEmpresaCategoria = 13, IdEmpresa = 13, IdCategoria = 2 }, // BBVA - Banca
        new EmpresaCategoria { IdEmpresaCategoria = 14, IdEmpresa = 14, IdCategoria = 9 }, // Amadeus - Tecnología
        new EmpresaCategoria { IdEmpresaCategoria = 15, IdEmpresa = 15, IdCategoria = 13 }, // Grifols - Farmacéutica
        new EmpresaCategoria { IdEmpresaCategoria = 16, IdEmpresa = 16, IdCategoria = 1 }, // Zara - Moda
        new EmpresaCategoria { IdEmpresaCategoria = 17, IdEmpresa = 17, IdCategoria = 12 }, // Mercadona - Alimentación
        new EmpresaCategoria { IdEmpresaCategoria = 18, IdEmpresa = 18, IdCategoria = 10 }, // Meliá Hotels - Hotelería
        new EmpresaCategoria { IdEmpresaCategoria = 19, IdEmpresa = 19, IdCategoria = 4 },  // Naturgy - Energía
        new EmpresaCategoria { IdEmpresaCategoria = 20, IdEmpresa = 20, IdCategoria = 16 }, // FCC - Construcción
        new EmpresaCategoria { IdEmpresaCategoria = 21, IdEmpresa = 21, IdCategoria = 16 }, // Sacyr - Construcción
        new EmpresaCategoria { IdEmpresaCategoria = 22, IdEmpresa = 22, IdCategoria = 3 },  // Cellnex - Telecomunicaciones
        new EmpresaCategoria { IdEmpresaCategoria = 23, IdEmpresa = 23, IdCategoria = 9 },  // Globalia - Tecnología
        new EmpresaCategoria { IdEmpresaCategoria = 24, IdEmpresa = 24, IdCategoria = 12 }, // Viscofan - Alimentación
        new EmpresaCategoria { IdEmpresaCategoria = 25, IdEmpresa = 25, IdCategoria = 4 },  // Cepsa - Energía
        new EmpresaCategoria { IdEmpresaCategoria = 26, IdEmpresa = 26, IdCategoria = 15 }, // Prosegur - Seguridad
        new EmpresaCategoria { IdEmpresaCategoria = 27, IdEmpresa = 27, IdCategoria = 9 },  // Indra - Tecnología
        new EmpresaCategoria { IdEmpresaCategoria = 28, IdEmpresa = 28, IdCategoria = 14 }, // Colonial - Inmobiliaria
        new EmpresaCategoria { IdEmpresaCategoria = 29, IdEmpresa = 29, IdCategoria = 10 }, // NH Hotel Group - Hotelería
        new EmpresaCategoria { IdEmpresaCategoria = 30, IdEmpresa = 30, IdCategoria = 12 }, // Ebro Foods - Alimentación
        new EmpresaCategoria { IdEmpresaCategoria = 31, IdEmpresa = 31, IdCategoria = 13 }, // Almirall - Farmacéutica
        new EmpresaCategoria { IdEmpresaCategoria = 32, IdEmpresa = 32, IdCategoria = 13 }, // Rovi - Farmacéutica
        new EmpresaCategoria { IdEmpresaCategoria = 33, IdEmpresa = 33, IdCategoria = 11 }, // Alsa - Transporte
        new EmpresaCategoria { IdEmpresaCategoria = 34, IdEmpresa = 34, IdCategoria = 12 }, // Viscofan - Alimentación
        new EmpresaCategoria { IdEmpresaCategoria = 35, IdEmpresa = 35, IdCategoria = 13 }, // Pharmamar - Farmacéutica
        new EmpresaCategoria { IdEmpresaCategoria = 36, IdEmpresa = 36, IdCategoria = 17 }  // Logista - Logística
    );


        // Semilla de datos para relaciones entre empresas y ciudades
        modelBuilder.Entity<EmpresaCiudad>().HasData(
            new EmpresaCiudad { IdEmpresaCiudad = 1, IdEmpresa = 1, IdCiudad = 1 }, // Inditex en La Coruña
            new EmpresaCiudad { IdEmpresaCiudad = 2, IdEmpresa = 1, IdCiudad = 2 }, // Inditex también en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 3, IdEmpresa = 2, IdCiudad = 3 }, // Banco Santander en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 4, IdEmpresa = 3, IdCiudad = 3 }, // Telefónica en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 5, IdEmpresa = 4, IdCiudad = 4 }, // Iberdrola en Bilbao
            new EmpresaCiudad { IdEmpresaCiudad = 6, IdEmpresa = 5, IdCiudad = 3 }, // Repsol en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 7, IdEmpresa = 6, IdCiudad = 3 }, // El Corte Inglés en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 8, IdEmpresa = 6, IdCiudad = 2 }, // El Corte Inglés en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 9, IdEmpresa = 7, IdCiudad = 2 }, // CaixaBank en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 10, IdEmpresa = 8, IdCiudad = 2 }, // Seat en Martorell
            new EmpresaCiudad { IdEmpresaCiudad = 11, IdEmpresa = 9, IdCiudad = 3 }, // Aena en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 12, IdEmpresa = 10, IdCiudad = 3 }, // Ferrovial en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 13, IdEmpresa = 11, IdCiudad = 3 }, // Mapfre en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 14, IdEmpresa = 12, IdCiudad = 3 }, // Acciona en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 15, IdEmpresa = 13, IdCiudad = 3 }, // BBVA en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 16, IdEmpresa = 14, IdCiudad = 3 }, // Amadeus en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 17, IdEmpresa = 15, IdCiudad = 2 }, // Grifols en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 18, IdEmpresa = 16, IdCiudad = 1 }, // Zara en La Coruña
            new EmpresaCiudad { IdEmpresaCiudad = 19, IdEmpresa = 16, IdCiudad = 2 }, // Zara también en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 20, IdEmpresa = 17, IdCiudad = 2 }, // Mercadona en Valencia
            new EmpresaCiudad { IdEmpresaCiudad = 21, IdEmpresa = 18, IdCiudad = 2 }, // Meliá Hotels en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 22, IdEmpresa = 19, IdCiudad = 3 }, // Naturgy en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 23, IdEmpresa = 20, IdCiudad = 3 }, // FCC en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 24, IdEmpresa = 21, IdCiudad = 3 }, // Sacyr en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 25, IdEmpresa = 22, IdCiudad = 3 }, // Cellnex en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 26, IdEmpresa = 23, IdCiudad = 2 }, // Globalia en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 27, IdEmpresa = 24, IdCiudad = 1 }, // Viscofan en La Coruña
            new EmpresaCiudad { IdEmpresaCiudad = 28, IdEmpresa = 25, IdCiudad = 3 }, // Cepsa en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 29, IdEmpresa = 26, IdCiudad = 3 }, // Prosegur en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 30, IdEmpresa = 27, IdCiudad = 3 }, // Indra en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 31, IdEmpresa = 28, IdCiudad = 3 }, // Colonial en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 32, IdEmpresa = 29, IdCiudad = 3 }, // NH Hotel Group en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 33, IdEmpresa = 30, IdCiudad = 3 }, // Ebro Foods en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 34, IdEmpresa = 31, IdCiudad = 2 }, // Almirall en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 35, IdEmpresa = 32, IdCiudad = 3 }, // Rovi en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 36, IdEmpresa = 33, IdCiudad = 3 }, // Alsa en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 37, IdEmpresa = 34, IdCiudad = 3 }, // Viscofan en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 38, IdEmpresa = 35, IdCiudad = 3 }, // Pharmamar en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 39, IdEmpresa = 36, IdCiudad = 3 }, // Logista en Madrid
            new EmpresaCiudad { IdEmpresaCiudad = 40, IdEmpresa = 15, IdCiudad = 1 }, // Grifols en La Coruña
            new EmpresaCiudad { IdEmpresaCiudad = 41, IdEmpresa = 18, IdCiudad = 1 }, // Meliá Hotels en La Coruña
            new EmpresaCiudad { IdEmpresaCiudad = 42, IdEmpresa = 26, IdCiudad = 1 }, // Prosegur en La Coruña
            new EmpresaCiudad { IdEmpresaCiudad = 43, IdEmpresa = 29, IdCiudad = 1 }, // NH Hotel Group en La Coruña
            new EmpresaCiudad { IdEmpresaCiudad = 44, IdEmpresa = 10, IdCiudad = 2 }, // Ferrovial en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 45, IdEmpresa = 12, IdCiudad = 4 }, // Acciona en Bilbao
            new EmpresaCiudad { IdEmpresaCiudad = 46, IdEmpresa = 19, IdCiudad = 4 }, // Naturgy en Bilbao
            new EmpresaCiudad { IdEmpresaCiudad = 47, IdEmpresa = 9, IdCiudad = 2 }, // Aena en Barcelona
            new EmpresaCiudad { IdEmpresaCiudad = 48, IdEmpresa = 1, IdCiudad = 3 }  // Inditex en Madrid
        );



        base.OnModelCreating(modelBuilder);

    }

    public DbSet<Ciudad> Ciudadades { get; set; } 
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<EmpresaCategoria> EmpresaCategorias { set; get; }
    public DbSet<EmpresaCiudad> EmpresasCiudades { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Peticion> Peticiones { get; set; }
    public DbSet<UsuarioEmpresa> UsuarioEmpresas { get; set; }
    public DbSet<Suscripcion> Suscripciones { get; set; }
    public DbSet<UsuarioSuscripcion> UsuarioSuscripciones { get; set; }
}
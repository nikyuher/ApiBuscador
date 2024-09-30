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

        // Configuración de la relación uno a muchos entre Usuario y Peticion
        modelBuilder.Entity<Peticion>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Peticiones)
            .HasForeignKey(p => p.IdUsuario);

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
    new Empresa { IdEmpresa = 1, Nombre = "Inditex", Descripcion = "Líder mundial en distribución de moda.", Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/inditexLC.jpg?updatedAt=1726649179851" },
    new Empresa { IdEmpresa = 2, Nombre = "Banco Santander", Descripcion = "Una de las mayores entidades bancarias del mundo.", Direccion = "Ciudad Grupo Santander, 28660 Boadilla del Monte, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/santander.jpg?updatedAt=1726649877238" },
    new Empresa { IdEmpresa = 3, Nombre = "Telefónica", Descripcion = "Multinacional española de telecomunicaciones.", Direccion = "Distrito Telefónica, 28050 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/telefonica.jpg?updatedAt=1726649877081" },
    new Empresa { IdEmpresa = 4, Nombre = "Iberdrola", Descripcion = "Una de las mayores empresas energéticas del mundo.", Direccion = "Plaza Euskadi 5, 48009 Bilbao", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/iberdrola-.jpg?updatedAt=1726649877427" },
    new Empresa { IdEmpresa = 5, Nombre = "Repsol", Descripcion = "Empresa energética multinacional española.", Direccion = "Calle Méndez Álvaro, 44, 28045 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458" },
    new Empresa { IdEmpresa = 6, Nombre = "El Corte Inglés", Descripcion = "Cadena de grandes almacenes más grande de Europa.", Direccion = "Calle Hermosilla, 112, 28009 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/elcorteingles.jpeg?updatedAt=1726649879087" },
    new Empresa { IdEmpresa = 7, Nombre = "CaixaBank", Descripcion = "Uno de los bancos más importantes de España.", Direccion = "Av. Diagonal, 621, 08028 Barcelona", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/caixabanck.jpg?updatedAt=1726649879170" },
    new Empresa { IdEmpresa = 8, Nombre = "Seat", Descripcion = "Fabricante de automóviles con sede en Martorell.", Direccion = "Autovía A-2, Km 585, 08760 Martorell, Barcelona", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/seat.jpg?updatedAt=1726649876969" },
    new Empresa { IdEmpresa = 9, Nombre = "Aena", Descripcion = "Gestión de aeropuertos en España y en el mundo.", Direccion = "Calle Peonías, 12, 28042 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/aena-aeropuerto.jpg?updatedAt=1726649877286" },
    new Empresa { IdEmpresa = 10, Nombre = "Ferrovial", Descripcion = "Empresa global de infraestructuras y servicios.", Direccion = "Calle Príncipe de Vergara, 135, 28002 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpeg?updatedAt=1726649879406" },
    new Empresa { IdEmpresa = 11, Nombre = "Mapfre", Descripcion = "Compañía de seguros global.", Direccion = "Carretera de Pozuelo, 52, 28220 Majadahonda, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/mafre.jpg?updatedAt=1726649877454" },
    new Empresa { IdEmpresa = 12, Nombre = "Acciona", Descripcion = "Líder en energías renovables y construcción sostenible.", Direccion = "Avenida de Europa, 18, 28108 Alcobendas, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/acciona.webp?updatedAt=1726649877393" },
    new Empresa { IdEmpresa = 13, Nombre = "BBVA", Descripcion = "Multinacional de banca y servicios financieros.", Direccion = "Calle Azul, 4, 28050 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/BBVA.jpg?updatedAt=1726649879175" },
    new Empresa { IdEmpresa = 14, Nombre = "Amadeus", Descripcion = "Proveedor líder de tecnología en la industria del viaje.", Direccion = "Calle Salvador de Madariaga, 1, 28027 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/amadeus.jpg?updatedAt=1726649879691" },
    new Empresa { IdEmpresa = 15, Nombre = "Grifols", Descripcion = "Líder global en el sector de los hemoderivados.", Direccion = "Calle Jesús i Maria, 6, 08022 Barcelona", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/grifols.jpg?updatedAt=1726649877212" },
    new Empresa { IdEmpresa = 16, Nombre = "Zara", Descripcion = "Una de las mayores marcas de moda del mundo.", Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/zara.jpg?updatedAt=1726649877219" },
    new Empresa { IdEmpresa = 17, Nombre = "Mercadona", Descripcion = "Cadena de supermercados líder en España.", Direccion = "Calle Valencia, 5, 46016 Tavernes Blanques, Valencia", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/mercadona.jpg?updatedAt=1726649879213" },
    new Empresa { IdEmpresa = 18, Nombre = "Meliá Hotels", Descripcion = "Cadena de hoteles con presencia internacional.", Direccion = "Calle Gremio Toneleros, 24, 07009 Palma, Islas Baleares", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/meliahotels.jpg?updatedAt=1726649879218" },
    new Empresa { IdEmpresa = 19, Nombre = "Naturgy", Descripcion = "Empresa multinacional de gas y electricidad.", Direccion = "Avenida de América, 38, 28028 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/naturgy.jpg?updatedAt=1726649879220" },
    new Empresa { IdEmpresa = 20, Nombre = "FCC", Descripcion = "Empresa de construcción y servicios.", Direccion = "Calle Federico Salmón, 13, 28016 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/fcc.jpg?updatedAt=1726649879225" },
    new Empresa { IdEmpresa = 21, Nombre = "Sacyr", Descripcion = "Multinacional en construcción e infraestructuras.", Direccion = "Calle Condesa de Venadito, 7, 28027 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/sacyr.jpg?updatedAt=1726649879229" },
    new Empresa { IdEmpresa = 22, Nombre = "Cellnex", Descripcion = "Operador europeo de infraestructuras de telecomunicaciones.", Direccion = "Calle Juan Esplandiú, 11, 28007 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/cellnex.jpg?updatedAt=1726649879231" },
    new Empresa { IdEmpresa = 23, Nombre = "Globalia", Descripcion = "Grupo turístico líder en España.", Direccion = "Calle de la Cruz, 1, 28760 Tres Cantos, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/globalia.jpg?updatedAt=1726649879233" },
    new Empresa { IdEmpresa = 24, Nombre = "Viscofan", Descripcion = "Líder mundial en envolturas alimentarias.", Direccion = "Polígono Industrial Berroa, 15, 31192 Tajonar, Navarra", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/viscofan.jpg?updatedAt=1726649879236" },
    new Empresa { IdEmpresa = 25, Nombre = "Cepsa", Descripcion = "Multinacional de energía.", Direccion = "Torre Cepsa, Paseo de la Castellana, 259A, 28046 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/cepsa.jpg?updatedAt=1726649879240" },
    new Empresa { IdEmpresa = 26, Nombre = "Prosegur", Descripcion = "Empresa líder en seguridad privada.", Direccion = "Calle Pajaritos, 24, 28007 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/prosegur.jpg?updatedAt=1726649879245" },
    new Empresa { IdEmpresa = 27, Nombre = "Indra", Descripcion = "Multinacional de consultoría y tecnología.", Direccion = "Avenida de Bruselas, 35, 28108 Alcobendas, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/indra.jpg?updatedAt=1726649879249" },
    new Empresa { IdEmpresa = 28, Nombre = "Colonial", Descripcion = "Empresa líder en el sector inmobiliario.", Direccion = "Paseo de la Castellana, 163, 28046 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/colonial.jpg?updatedAt=1726649879252" },
    new Empresa { IdEmpresa = 29, Nombre = "NH Hotel Group", Descripcion = "Cadena hotelera con presencia internacional.", Direccion = "Calle Santa Engracia, 120, 28003 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/nhhotelgroup.jpg?updatedAt=1726649879256" },
    new Empresa { IdEmpresa = 30, Nombre = "Ebro Foods", Descripcion = "Líder en el sector alimentario.", Direccion = "Calle del Prado, 6, 28014 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/ebrofoods.jpg?updatedAt=1726649879261" },
    new Empresa { IdEmpresa = 31, Nombre = "Almirall", Descripcion = "Compañía farmacéutica internacional.", Direccion = "Ronda General Mitre, 151, 08022 Barcelona", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/almirall.jpg?updatedAt=1726649879266" },
    new Empresa { IdEmpresa = 32, Nombre = "Rovi", Descripcion = "Empresa farmacéutica especializada en productos inyectables.", Direccion = "Calle Julián Camarillo, 35, 28037 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/rovi.jpg?updatedAt=1726649879270" },
    new Empresa { IdEmpresa = 33, Nombre = "Alsa", Descripcion = "Operador líder en transporte de pasajeros.", Direccion = "Calle Miguel Fleta, 4, 28037 Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/alsa.jpg?updatedAt=1726649879275" },
    new Empresa { IdEmpresa = 34, Nombre = "Viscofan", Descripcion = "Multinacional de productos de colágeno y envolturas.", Direccion = "Polígono Berroa, 15, 31192 Tajonar, Navarra", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/viscofan.jpg?updatedAt=1726649879279" },
    new Empresa { IdEmpresa = 35, Nombre = "Pharmamar", Descripcion = "Empresa farmacéutica especializada en productos oncológicos.", Direccion = "Avenida de los Reyes, 1, 28760 Tres Cantos, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/pharmamar.jpg?updatedAt=1726649879283" },
    new Empresa { IdEmpresa = 36, Nombre = "Logista", Descripcion = "Distribuidora líder en el sur de Europa.", Direccion = "Avenida de la Vega, 1, 28108 Alcobendas, Madrid", Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/logista.jpg?updatedAt=1726649879286" }
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
}
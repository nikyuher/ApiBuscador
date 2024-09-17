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

        modelBuilder.Entity<Empresa>().HasData(
    new Empresa { IdEmpresa = 1, Nombre = "Inditex", Descripcion = "Líder mundial en distribución de moda.", Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña", Imagen = "https://example.com/inditex.png" },
    new Empresa { IdEmpresa = 2, Nombre = "Banco Santander", Descripcion = "Una de las mayores entidades bancarias del mundo.", Direccion = "Ciudad Grupo Santander, 28660 Boadilla del Monte, Madrid", Imagen = "https://example.com/santander.png" },
    new Empresa { IdEmpresa = 3, Nombre = "Telefónica", Descripcion = "Multinacional española de telecomunicaciones.", Direccion = "Distrito Telefónica, 28050 Madrid", Imagen = "https://example.com/telefonica.png" },
    new Empresa { IdEmpresa = 4, Nombre = "Iberdrola", Descripcion = "Una de las mayores empresas energéticas del mundo.", Direccion = "Plaza Euskadi 5, 48009 Bilbao", Imagen = "https://example.com/iberdrola.png" },
    new Empresa { IdEmpresa = 5, Nombre = "Repsol", Descripcion = "Empresa energética multinacional española.", Direccion = "Calle Méndez Álvaro, 44, 28045 Madrid", Imagen = "https://example.com/repsol.png" },
    new Empresa { IdEmpresa = 6, Nombre = "El Corte Inglés", Descripcion = "Cadena de grandes almacenes más grande de Europa.", Direccion = "Calle Hermosilla, 112, 28009 Madrid", Imagen = "https://example.com/elcorteingles.png" },
    new Empresa { IdEmpresa = 7, Nombre = "CaixaBank", Descripcion = "Uno de los bancos más importantes de España.", Direccion = "Av. Diagonal, 621, 08028 Barcelona", Imagen = "https://example.com/caixabank.png" },
    new Empresa { IdEmpresa = 8, Nombre = "Seat", Descripcion = "Fabricante de automóviles con sede en Martorell.", Direccion = "Autovía A-2, Km 585, 08760 Martorell, Barcelona", Imagen = "https://example.com/seat.png" },
    new Empresa { IdEmpresa = 9, Nombre = "Aena", Descripcion = "Gestión de aeropuertos en España y en el mundo.", Direccion = "Calle Peonías, 12, 28042 Madrid", Imagen = "https://example.com/aena.png" },
    new Empresa { IdEmpresa = 10, Nombre = "Ferrovial", Descripcion = "Empresa global de infraestructuras y servicios.", Direccion = "Calle Príncipe de Vergara, 135, 28002 Madrid", Imagen = "https://example.com/ferrovial.png" },
    new Empresa { IdEmpresa = 11, Nombre = "Mapfre", Descripcion = "Compañía de seguros global.", Direccion = "Carretera de Pozuelo, 52, 28220 Majadahonda, Madrid", Imagen = "https://example.com/mapfre.png" },
    new Empresa { IdEmpresa = 12, Nombre = "Acciona", Descripcion = "Líder en energías renovables y construcción sostenible.", Direccion = "Avenida de Europa, 18, 28108 Alcobendas, Madrid", Imagen = "https://example.com/acciona.png" },
    new Empresa { IdEmpresa = 13, Nombre = "BBVA", Descripcion = "Multinacional de banca y servicios financieros.", Direccion = "Calle Azul, 4, 28050 Madrid", Imagen = "https://example.com/bbva.png" },
    new Empresa { IdEmpresa = 14, Nombre = "Amadeus", Descripcion = "Proveedor líder de tecnología en la industria del viaje.", Direccion = "Calle Salvador de Madariaga, 1, 28027 Madrid", Imagen = "https://example.com/amadeus.png" },
    new Empresa { IdEmpresa = 15, Nombre = "Grifols", Descripcion = "Líder global en el sector de los hemoderivados.", Direccion = "Calle Jesús i Maria, 6, 08022 Barcelona", Imagen = "https://example.com/grifols.png" },
    // Agregar más empresas reales aquí...
    new Empresa { IdEmpresa = 30, Nombre = "Zara", Descripcion = "Una de las mayores marcas de moda del mundo.", Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña", Imagen = "https://example.com/zara.png" }
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
    new EmpresaCiudad { IdEmpresaCiudad = 10, IdEmpresa = 8, IdCiudad = 2 }, // Seat en Martorell (cerca de Barcelona)
    new EmpresaCiudad { IdEmpresaCiudad = 11, IdEmpresa = 9, IdCiudad = 3 }, // Aena en Madrid
    new EmpresaCiudad { IdEmpresaCiudad = 12, IdEmpresa = 10, IdCiudad = 3 }, // Ferrovial en Madrid
    new EmpresaCiudad { IdEmpresaCiudad = 13, IdEmpresa = 11, IdCiudad = 3 }, // Mapfre en Madrid
    new EmpresaCiudad { IdEmpresaCiudad = 14, IdEmpresa = 12, IdCiudad = 3 }, // Acciona en Madrid
    new EmpresaCiudad { IdEmpresaCiudad = 15, IdEmpresa = 13, IdCiudad = 3 }, // BBVA en Madrid
    new EmpresaCiudad { IdEmpresaCiudad = 16, IdEmpresa = 14, IdCiudad = 3 }, // Amadeus en Madrid
    new EmpresaCiudad { IdEmpresaCiudad = 17, IdEmpresa = 15, IdCiudad = 2 }, // Grifols en Barcelona.
    new EmpresaCiudad { IdEmpresaCiudad = 18, IdEmpresa = 30, IdCiudad = 1 }, // Zara en La Coruña
    new EmpresaCiudad { IdEmpresaCiudad = 19, IdEmpresa = 30, IdCiudad = 2 }  // Zara también en Barcelona
);


        base.OnModelCreating(modelBuilder);

    }
    
    public DbSet<Ciudad> Ciudadades { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<EmpresaCategoria> EmpresaCategorias { set; get; }
    public DbSet<EmpresaCiudad> EmpresasCiudades { get; set; }

}
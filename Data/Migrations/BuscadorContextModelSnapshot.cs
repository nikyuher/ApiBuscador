﻿// <auto-generated />
using Buscador.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Buscador.Data.Migrations
{
    [DbContext(typeof(BuscadorContext))]
    partial class BuscadorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Buscador.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Buscador.Models.Ciudad", b =>
                {
                    b.Property<int>("IdCiudad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCiudad"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCiudad");

                    b.ToTable("Ciudadades");

                    b.HasData(
                        new
                        {
                            IdCiudad = 1,
                            Nombre = "Madrid"
                        },
                        new
                        {
                            IdCiudad = 2,
                            Nombre = "Barcelona"
                        },
                        new
                        {
                            IdCiudad = 3,
                            Nombre = "Valencia"
                        },
                        new
                        {
                            IdCiudad = 4,
                            Nombre = "Sevilla"
                        },
                        new
                        {
                            IdCiudad = 5,
                            Nombre = "Zaragoza"
                        },
                        new
                        {
                            IdCiudad = 6,
                            Nombre = "Málaga"
                        },
                        new
                        {
                            IdCiudad = 7,
                            Nombre = "Murcia"
                        },
                        new
                        {
                            IdCiudad = 8,
                            Nombre = "Palma de Mallorca"
                        },
                        new
                        {
                            IdCiudad = 9,
                            Nombre = "Las Palmas de Gran Canaria"
                        },
                        new
                        {
                            IdCiudad = 10,
                            Nombre = "Bilbao"
                        },
                        new
                        {
                            IdCiudad = 11,
                            Nombre = "Alicante"
                        },
                        new
                        {
                            IdCiudad = 12,
                            Nombre = "Córdoba"
                        },
                        new
                        {
                            IdCiudad = 13,
                            Nombre = "Valladolid"
                        },
                        new
                        {
                            IdCiudad = 14,
                            Nombre = "Vigo"
                        },
                        new
                        {
                            IdCiudad = 15,
                            Nombre = "Gijón"
                        },
                        new
                        {
                            IdCiudad = 16,
                            Nombre = "Eibar"
                        },
                        new
                        {
                            IdCiudad = 17,
                            Nombre = "Tarragona"
                        },
                        new
                        {
                            IdCiudad = 18,
                            Nombre = "Lérida"
                        },
                        new
                        {
                            IdCiudad = 19,
                            Nombre = "Huelva"
                        },
                        new
                        {
                            IdCiudad = 20,
                            Nombre = "Granada"
                        },
                        new
                        {
                            IdCiudad = 21,
                            Nombre = "Jaén"
                        },
                        new
                        {
                            IdCiudad = 22,
                            Nombre = "Almería"
                        },
                        new
                        {
                            IdCiudad = 23,
                            Nombre = "Toledo"
                        },
                        new
                        {
                            IdCiudad = 24,
                            Nombre = "Salamanca"
                        },
                        new
                        {
                            IdCiudad = 25,
                            Nombre = "Segovia"
                        },
                        new
                        {
                            IdCiudad = 26,
                            Nombre = "Soria"
                        },
                        new
                        {
                            IdCiudad = 27,
                            Nombre = "Badajoz"
                        },
                        new
                        {
                            IdCiudad = 28,
                            Nombre = "Cáceres"
                        },
                        new
                        {
                            IdCiudad = 29,
                            Nombre = "Logroño"
                        },
                        new
                        {
                            IdCiudad = 30,
                            Nombre = "Pamplona"
                        });
                });

            modelBuilder.Entity("Buscador.Models.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresa"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpresa");

                    b.ToTable("Empresas");

                    b.HasData(
                        new
                        {
                            IdEmpresa = 1,
                            Descripcion = "Líder mundial en distribución de moda.",
                            Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/inditexLC.jpg?updatedAt=1726649179851",
                            Nombre = "Inditex"
                        },
                        new
                        {
                            IdEmpresa = 2,
                            Descripcion = "Una de las mayores entidades bancarias del mundo.",
                            Direccion = "Ciudad Grupo Santander, 28660 Boadilla del Monte, Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/santander.jpg?updatedAt=1726649877238",
                            Nombre = "Banco Santander"
                        },
                        new
                        {
                            IdEmpresa = 3,
                            Descripcion = "Multinacional española de telecomunicaciones.",
                            Direccion = "Distrito Telefónica, 28050 Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/telefonica.jpg?updatedAt=1726649877081",
                            Nombre = "Telefónica"
                        },
                        new
                        {
                            IdEmpresa = 4,
                            Descripcion = "Una de las mayores empresas energéticas del mundo.",
                            Direccion = "Plaza Euskadi 5, 48009 Bilbao",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/iberdrola-.jpg?updatedAt=1726649877427",
                            Nombre = "Iberdrola"
                        },
                        new
                        {
                            IdEmpresa = 5,
                            Descripcion = "Empresa energética multinacional española.",
                            Direccion = "Calle Méndez Álvaro, 44, 28045 Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/repsol.webp?updatedAt=1726649877458",
                            Nombre = "Repsol"
                        },
                        new
                        {
                            IdEmpresa = 6,
                            Descripcion = "Cadena de grandes almacenes más grande de Europa.",
                            Direccion = "Calle Hermosilla, 112, 28009 Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/elcorteingles.jpeg?updatedAt=1726649879087",
                            Nombre = "El Corte Inglés"
                        },
                        new
                        {
                            IdEmpresa = 7,
                            Descripcion = "Uno de los bancos más importantes de España.",
                            Direccion = "Av. Diagonal, 621, 08028 Barcelona",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/caixabanck.jpg?updatedAt=1726649879170",
                            Nombre = "CaixaBank"
                        },
                        new
                        {
                            IdEmpresa = 8,
                            Descripcion = "Fabricante de automóviles con sede en Martorell.",
                            Direccion = "Autovía A-2, Km 585, 08760 Martorell, Barcelona",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/seat.jpg?updatedAt=1726649876969",
                            Nombre = "Seat"
                        },
                        new
                        {
                            IdEmpresa = 9,
                            Descripcion = "Gestión de aeropuertos en España y en el mundo.",
                            Direccion = "Calle Peonías, 12, 28042 Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/aena-aeropuerto.jpg?updatedAt=1726649877286",
                            Nombre = "Aena"
                        },
                        new
                        {
                            IdEmpresa = 10,
                            Descripcion = "Empresa global de infraestructuras y servicios.",
                            Direccion = "Calle Príncipe de Vergara, 135, 28002 Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/ferrovial.jpeg?updatedAt=1726649879406",
                            Nombre = "Ferrovial"
                        },
                        new
                        {
                            IdEmpresa = 11,
                            Descripcion = "Compañía de seguros global.",
                            Direccion = "Carretera de Pozuelo, 52, 28220 Majadahonda, Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/mafre.jpg?updatedAt=1726649877454",
                            Nombre = "Mapfre"
                        },
                        new
                        {
                            IdEmpresa = 12,
                            Descripcion = "Líder en energías renovables y construcción sostenible.",
                            Direccion = "Avenida de Europa, 18, 28108 Alcobendas, Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/acciona.webp?updatedAt=1726649877393",
                            Nombre = "Acciona"
                        },
                        new
                        {
                            IdEmpresa = 13,
                            Descripcion = "Multinacional de banca y servicios financieros.",
                            Direccion = "Calle Azul, 4, 28050 Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/BBVA.jpg?updatedAt=1726649879175",
                            Nombre = "BBVA"
                        },
                        new
                        {
                            IdEmpresa = 14,
                            Descripcion = "Proveedor líder de tecnología en la industria del viaje.",
                            Direccion = "Calle Salvador de Madariaga, 1, 28027 Madrid",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/amadeus.jpg?updatedAt=1726649879691",
                            Nombre = "Amadeus"
                        },
                        new
                        {
                            IdEmpresa = 15,
                            Descripcion = "Líder global en el sector de los hemoderivados.",
                            Direccion = "Calle Jesús i Maria, 6, 08022 Barcelona",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/grifols.jpg?updatedAt=1726649877212",
                            Nombre = "Grifols"
                        },
                        new
                        {
                            IdEmpresa = 16,
                            Descripcion = "Una de las mayores marcas de moda del mundo.",
                            Direccion = "Av. de la Diputación, 15142 Arteijo, La Coruña",
                            Imagen = "https://ik.imagekit.io/Mariocanizares/Empresas/zara.jpg?updatedAt=1726649877219",
                            Nombre = "Zara"
                        });
                });

            modelBuilder.Entity("Buscador.Models.EmpresaCategoria", b =>
                {
                    b.Property<int>("IdEmpresaCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresaCategoria"), 1L, 1);

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.HasKey("IdEmpresaCategoria");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("EmpresaCategorias");
                });

            modelBuilder.Entity("Buscador.Models.EmpresaCiudad", b =>
                {
                    b.Property<int>("IdEmpresaCiudad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresaCiudad"), 1L, 1);

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.HasKey("IdEmpresaCiudad");

                    b.HasIndex("IdCiudad");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("EmpresasCiudades");
                });

            modelBuilder.Entity("Buscador.Models.EmpresaCategoria", b =>
                {
                    b.HasOne("Buscador.Models.Categoria", "Categoria")
                        .WithMany("EmpresaCategorias")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buscador.Models.Empresa", "Empresa")
                        .WithMany("EmpresaCategorias")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Buscador.Models.EmpresaCiudad", b =>
                {
                    b.HasOne("Buscador.Models.Ciudad", "Ciudad")
                        .WithMany("EmpresasCiudades")
                        .HasForeignKey("IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buscador.Models.Empresa", "Empresa")
                        .WithMany("EmpresasCiudades")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Buscador.Models.Categoria", b =>
                {
                    b.Navigation("EmpresaCategorias");
                });

            modelBuilder.Entity("Buscador.Models.Ciudad", b =>
                {
                    b.Navigation("EmpresasCiudades");
                });

            modelBuilder.Entity("Buscador.Models.Empresa", b =>
                {
                    b.Navigation("EmpresaCategorias");

                    b.Navigation("EmpresasCiudades");
                });
#pragma warning restore 612, 618
        }
    }
}

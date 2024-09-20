﻿// <auto-generated />
using Buscador.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Buscador.Data.Migrations
{
    [DbContext(typeof(BuscadorContext))]
    [Migration("20240917120839_Migracion")]
    partial class Migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

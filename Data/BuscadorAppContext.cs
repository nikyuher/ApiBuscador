namespace Buscador.Data;

using Microsoft.EntityFrameworkCore;
using Buscador.Models;

public class BuscadorAppContext : DbContext
{

    public BuscadorAppContext(DbContextOptions<BuscadorAppContext> options)
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

        base.OnModelCreating(modelBuilder);

    }
    
    public DbSet<Ciudad> Ciudadades { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<EmpresaCategoria> EmpresaCategorias { set; get; }
    public DbSet<EmpresaCiudad> EmpresasCiudades { get; set; }

}
namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class EmpresaCategoria


{
    [Key]
    public int IdEmpresaCategoria { get; set; }
    
    public int IdCategoria { get; set; }
    public Categoria? Categoria { get; set; }

    public int IdEmpresa { get; set; }
    public Empresa? Empresa { get; set; }
}
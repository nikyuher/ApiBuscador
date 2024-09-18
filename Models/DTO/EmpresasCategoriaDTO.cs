namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class EmpresasCategoriaDTO


{
    [Key]
    public int IdEmpresaCategoria { get; set; }
    
    public NameEmpresaDTO? Empresa { get; set; }
}
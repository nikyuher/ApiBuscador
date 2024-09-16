namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class EmpresaCiudad


{
    [Key]
    public int IdEmpresaCiudad { get; set; }
    
    public int IdCiudad { get; set; }
    public Ciudad? Ciudad { get; set; }

    public int IdEmpresa { get; set; }
    public Empresa? Empresa { get; set; }

}
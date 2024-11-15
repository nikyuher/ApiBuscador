namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class NameEmpresaCiudadDTO


{
    [Key]
    public int IdEmpresaCiudad { get; set; }
    
    public DatosCortosDTO? Empresa { get; set; }

}
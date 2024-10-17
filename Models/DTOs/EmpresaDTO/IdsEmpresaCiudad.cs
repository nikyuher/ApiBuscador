namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class IdsEmpresaCiudadDTO


{
    [Key]
    public int IdEmpresaCiudad { get; set; }
    public int IdCiudad { get; set; }
}
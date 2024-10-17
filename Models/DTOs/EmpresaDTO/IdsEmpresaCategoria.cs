namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class IdsEmpresaCategoriaDTO

{
    [Key]
    public int IdEmpresaCategoria { get; set; }
    public int IdCategoria { get; set; }
}
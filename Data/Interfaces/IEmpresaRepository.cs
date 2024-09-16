using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Data{
    public interface IEmpresaRepository{
       public List<Empresa> GetAll();
    }
}
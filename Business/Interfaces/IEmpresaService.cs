using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Data{
    public interface IEmpresaService{
       public List<Empresa> GetAll();
    }
}
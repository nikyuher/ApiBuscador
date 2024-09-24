using Buscador.Models;
using System.Security.Claims;
namespace Buscador.Data;
public interface IAuthService
{
    //Auth

    string GenerateJwtToken(Usuario usuario);
    public bool HasAccessToResource(ClaimsPrincipal user, int resourceOwnerId);
}
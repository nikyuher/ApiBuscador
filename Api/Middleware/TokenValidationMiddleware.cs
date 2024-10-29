
using System.Security.Claims;
using Buscador.Data; 

namespace Buscador.Api.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TokenValidationMiddleware> _logger;

        public TokenValidationMiddleware(RequestDelegate next, ILogger<TokenValidationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, BuscadorContext dbContext)
        {
            if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
            {
                var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
                var passwordChangedAtClaim = context.User.FindFirst("PasswordChangedAt");

                if (userIdClaim != null && passwordChangedAtClaim != null)
                {
                    if (int.TryParse(userIdClaim.Value, out int userId) &&
                        DateTime.TryParse(passwordChangedAtClaim.Value, out DateTime tokenPasswordChangedAt))
                    {
                        var usuario = await dbContext.Usuarios.FindAsync(userId);
                        if (usuario != null)
                        {
                            // Convertir ambos DateTime a UTC para evitar discrepancias de zona horaria
                            var tokenPasswordChangedAtUtc = tokenPasswordChangedAt.ToUniversalTime();
                            var dbPasswordChangedAtUtc = usuario.PasswordChangedAt.ToUniversalTime();

                            if (dbPasswordChangedAtUtc > tokenPasswordChangedAtUtc)
                            {
                                // Contraseña ha sido cambiada después de la emisión del token
                                _logger.LogWarning($"Token inválido para el usuario ID {userId} debido a un cambio de contraseña reciente.");
                                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                await context.Response.WriteAsync("Token inválido debido al cambio de contraseña. Por favor, inicie sesión nuevamente.");
                                return;
                            }
                        }
                    }
                }
            }

            // Continuar con el siguiente middleware en el pipeline
            await _next(context);
        }
    }
}

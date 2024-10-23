using Buscador.Business;
using Microsoft.Extensions.DependencyInjection;

namespace Buscador.Jobs
{
    public static class JobScheduler
    {
        public static async Task VerificarSuscripciones(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<ISuscripcionService>();
                await service.VerificarSuscripciones();
            }
        }
    }
}
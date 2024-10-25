using Hangfire.Dashboard;
namespace Buscador.Api.Middleware
{
    public class AllowAllUsersAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}

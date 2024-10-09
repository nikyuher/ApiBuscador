namespace Buscador.Business
{
    public interface IEmailService
    {
        Task EnviarCorreoAsync(string to, string subject, string body);
    }
}

using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Security;
using System.Threading.Tasks;

namespace Buscador.Business
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarCorreoAsync(string to, string subject, string body)
        {
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentException("La dirección de correo electrónico no puede ser nula o vacía.", nameof(to));
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration["Email:FromName"], _configuration["Email:FromEmail"]));
            emailMessage.To.Add(new MailboxAddress(to, to));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder { TextBody = body };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    // Cambiar esta línea
                    await client.ConnectAsync(_configuration["Email:SmtpHost"], int.Parse(_configuration["Email:SmtpPort"]), SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_configuration["Email:SmtpUser"], _configuration["Email:SmtpPass"]);
                    await client.SendAsync(emailMessage);
                }
                catch (SmtpCommandException smtpEx)
                {
                    throw new Exception($"Error en el comando SMTP: {smtpEx.Message}");
                }
                catch (SmtpProtocolException protocolEx)
                {
                    throw new Exception($"Error de protocolo SMTP: {protocolEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al enviar el correo: {ex.Message}");
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}

using SendGrid;
using SendGrid.Helpers.Mail;

namespace ESOF.WebApp.WebAPI.Services;


public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message);
}

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var apiKey = _configuration["SendGrid:ApiKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@yourapp.com", "YourApp");
        var to = new EmailAddress(email);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
        
        var response = await client.SendEmailAsync(msg);
        
        // Tratamento de erros (opcional)
        if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
        {
            // Log de erro ou tratamento adequado
            throw new ApplicationException($"Failed to send email. Status code: {response.StatusCode}");
        }
    }
}
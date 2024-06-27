using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public interface INotificationService
{
    Task SendNotificationAsync(string userId, string message);
}

public class NotificationService : INotificationService
{
    private readonly ApplicationDbContext _context;
    private readonly IEmailService _emailService; // Dependendo da sua implementação para enviar notificações por email

    public NotificationService(ApplicationDbContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task SendNotificationAsync(string userId, string message)
    {
        // Salvar a notificação no banco de dados
        var notification = new Notification
        {
            UserId = userId,
            Message = message,
            SentAt = DateTime.UtcNow,
            IsRead = false
        };
        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();

        // Enviar a notificação por email
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user != null)
        {
            await _emailService.SendEmailAsync(user.Email, "Nova Notificação", message);
        }
    }
}

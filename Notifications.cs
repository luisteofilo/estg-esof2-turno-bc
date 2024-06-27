using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class Notification
{
        public int Id { get; set; }
        public string UserId { get; set; } // ID do usuário que receberá a notificação
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
}

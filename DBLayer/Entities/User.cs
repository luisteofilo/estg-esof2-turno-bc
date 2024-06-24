using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    
    [EmailAddress, Required]
    public string Email { get; set; }
    
    [Required]
    public byte[] PasswordHash { get; set; }
    
    [Required]
    public byte[] PasswordSalt { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    
    public ICollection<BlindEvent> OrganizedEvents { get; set; }

    // Lista de eventos em que o utilizador está a participar
    public ICollection<Participant> Participants { get; set; }

    public User()
    {
        OrganizedEvents = new List<BlindEvent>();
        Participants = new List<Participant>();
    }
}
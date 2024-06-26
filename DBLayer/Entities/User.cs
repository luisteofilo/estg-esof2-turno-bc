using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    
    [EmailAddress, Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public DateTime BirthdayDate { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<EventParticipant> EventParticipants { get; set; }
}
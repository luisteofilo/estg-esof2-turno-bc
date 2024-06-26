using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class UserProfileDto
{
    public Guid UserId { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [EmailAddress, Required]
    public string Email { get; set; }
    
    public Guid WineId { get; set; }
    public WineDto FavoriteWine { get; set; }
}
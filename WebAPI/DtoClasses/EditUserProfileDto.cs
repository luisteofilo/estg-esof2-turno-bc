using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class EditUserProfileDto
{
    public Guid UserId { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [EmailAddress, Required]
    public string Email { get; set; }
    
    public WineDto FavoriteWine { get; set; }
}
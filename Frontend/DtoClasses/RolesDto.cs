using System.ComponentModel.DataAnnotations;

namespace Frontend.DtoClasses;

public class RolesDto
{
    public Guid RoleId { get; set; }
    
    [Required]
    public string Name { get; set; }
}   
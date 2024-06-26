using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class RegionDto
{
    public Guid RegionId { get; set; }
    
    [Required]
    public string Name { get; set; }
}
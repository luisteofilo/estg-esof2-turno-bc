using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class BrandDto
{
    public Guid BrandId { get; set; }
    
    [Required]
    public string Name { get; set; }
}
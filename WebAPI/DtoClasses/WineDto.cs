using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class WineDto
{
    public Guid WineId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public BrandDto Brand { get; set; }
    public RegionDto Region { get; set; }
}
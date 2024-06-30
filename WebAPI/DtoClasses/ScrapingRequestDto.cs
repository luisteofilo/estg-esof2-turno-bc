using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ScrapingRequestDto
{
    [Required]
    public string Url { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class Vinho
{
    [Key]
    public Guid vinhoid { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Tipo { get; set; }
    
}
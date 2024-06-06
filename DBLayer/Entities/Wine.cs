namespace ESOF.WebApp.DBLayer.Entities;
using System.ComponentModel.DataAnnotations;

public class Wine
{
    [Key]
    public Guid WineId { get; set; }
    
    [Required]
    public string label { get; set; }
    [Required]
    public int Year { get; set; }
    
    public string LabelDesignation { get; set; }
    [Required]
    public double Alcohol { get; set; }
    
    public decimal MinimumPrice { get; set; }
    public decimal MaximumPrice { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }
    
    public Guid RegionId { get; set; }
    public Region Region { get; set; }
    
    public ICollection<WineCategoryLink> WineCategoryLinks { get; set; }
    public ICollection<WineGrapeTypeLink> WineGrapeTypeLinks { get; set; }

}
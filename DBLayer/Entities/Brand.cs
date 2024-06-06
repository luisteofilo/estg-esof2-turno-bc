namespace ESOF.WebApp.DBLayer.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public class Brand
{
    [Key]
    public Guid BrandId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Description { get; set; }

    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public ICollection<Wine> Wines { get; set; }
    
}
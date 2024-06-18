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


    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }
    
    public ICollection<Wine> Wines { get; set; }
    
    public Brand()
    {
        Wines = new List<Wine>();
    }
    
}
namespace ESOF.WebApp.DBLayer.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public class BrandDto
{
    public Guid BrandId { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }


    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }
    
    public ICollection<Wine> Wines { get; set; }
    
    public BrandDto()
    {
        Wines = new List<Wine>();
    }
    
}
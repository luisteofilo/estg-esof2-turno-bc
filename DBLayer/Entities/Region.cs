namespace ESOF.WebApp.DBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Region
{
    [Key]
    public Guid RegionId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }
    
    public ICollection<Wine> Wines { get; set; }
    
    public Region()
    {
        Wines = new List<Wine>();
    }
}
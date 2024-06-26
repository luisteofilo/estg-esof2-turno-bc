namespace ESOF.WebApp.DBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class RegionDto
{
    public Guid RegionId { get; set; }
    
    public string Name { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }
    
    public ICollection<Wine> Wines { get; set; }
    
    public RegionDto()
    {
        Wines = new List<Wine>();
    }
}
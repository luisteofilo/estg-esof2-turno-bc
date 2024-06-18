namespace ESOF.WebApp.DBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class GrapeType
{
    [Key]
    public Guid GrapeTypeId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }

    public ICollection<WineGrapeTypeLink> WineGrapeTypes { get; set; }
    
    public GrapeType()
    {
        WineGrapeTypes = new List<WineGrapeTypeLink>();
    }
}
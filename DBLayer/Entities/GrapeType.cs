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
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<WineGrapeTypeLink> WineGrapeTypes { get; set; }
}
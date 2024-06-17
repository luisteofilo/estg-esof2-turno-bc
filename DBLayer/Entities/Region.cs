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

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Wine> Wines { get; set; }
}
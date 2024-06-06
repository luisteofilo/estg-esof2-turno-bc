namespace ESOF.WebApp.DBLayer.Entities;
using System;
using System.ComponentModel.DataAnnotations;

public class WineCategoryLink
{
    [Key]
    public Guid WineCategoryLinkId { get; set; }
    public Guid WineId { get; set; }
    public Wine Wine { get; set; } 
    public WineCategory CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
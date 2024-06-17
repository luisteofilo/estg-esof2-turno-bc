using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class WineGrapeTypeLink
{
    [Key]
    public Guid WineGrapeTypeLinkId { get; set; } 
    public Guid WineId { get; set; }
    public Wine Wine { get; set; }
    public Guid GrapeTypeId { get; set; }
    public GrapeType GrapeType { get; set; }


    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
namespace ESOF.WebApp.DBLayer.Entities;
using System.ComponentModel.DataAnnotations;

public class Wine
{
    [Key]
    public Guid WineId { get; set; }
    [Required]
    public Guid BrandId { get; set; }
    [Required]
    public Brand Brand { get; set; }
    [Required]
    public Guid RegionId { get; set; }
    [Required]
    public Region Region { get; set; }
    [Required]
    public string label { get; set; }
    [Required]
    public int Year { get; set; }
    public string? category { get; set; }
    public string? LabelDesignation { get; set; }
  
    public double? Alcohol { get; set; }
    
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
    
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }
    
    public ICollection<WineGrapeTypeLink> WineGrapeTypeLinks { get; set; }
    
    public ICollection<Interaction> WineInteractions { get; set; }
    
    public ICollection<Evaluation> Evaluations { get; set; }
    public ICollection<ParticipantWine> ParticipantWines { get; set; }

    public Wine()
    {
        WineGrapeTypeLinks = new List<WineGrapeTypeLink>();
        WineInteractions = new List<Interaction>();
        Evaluations = new List<Evaluation>();
        ParticipantWines = new List<ParticipantWine>();
    }

}
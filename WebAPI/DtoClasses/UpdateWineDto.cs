namespace ESOF.WebApp.WebAPI.DtoClasses;

public class UpdateWineDto
{
    public string? Label { get; set; }
    public int Year { get; set; }
    public string? Category { get; set; }
    public string? LabelDesignation { get; set; }
    public double? Alcohol { get; set; }
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
    public Guid BrandId { get; set; }
    public Guid RegionId { get; set; }
    public ICollection<Guid>? GrapeTypeIds { get; set; } 
}
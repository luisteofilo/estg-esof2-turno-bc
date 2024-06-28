namespace Frontend.DtoClasses;

public class WineDto
{
    public Guid WineId { get; set; }
    public Guid BrandId { get; set; }
    public Guid RegionId { get; set; }
    public string label { get; set; }
    public int Year { get; set; }
    public string? category { get; set; }
    public string? LabelDesignation { get; set; }
    public double? Alcohol { get; set; }
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
}
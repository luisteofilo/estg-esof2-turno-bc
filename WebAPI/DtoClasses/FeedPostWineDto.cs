namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostWineDto
{
    public Guid WineId { get; set; }
    public string Label { get; set; }
    public int Year { get; set; }
    public string Category { get; set; }
    public string LabelDesignation { get; set; }
    public double? Alcohol { get; set; }
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid BrandId { get; set; }     
    public Guid RegionId { get; set; }    
    public ResponseBrandDto Brand { get; set; }
    public ResponseRegionDto Region { get; set; }
}
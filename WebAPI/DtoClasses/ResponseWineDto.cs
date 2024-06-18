namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseWineDto
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
    public IEnumerable<Guid> GrapeTypeIds { get; set; } = new List<Guid>(); 
    public ResponseBrandDto Brand { get; set; }
    public ResponseRegionDto Region { get; set; }
    public List<ResponseGrapeTypeDto> GrapeTypes { get; set; } 
}
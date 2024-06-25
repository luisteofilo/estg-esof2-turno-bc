using System.ComponentModel;
 
namespace Helpers.ViewModels;

[TypeConverter(typeof(WineConverter))]
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

    // estes campos são para mostrar os dados relacionados em completa informação
    public ResponseBrandDto Brand { get; set; }
    public ResponseRegionDto Region { get; set; }
    public List<ResponseGrapeTypeDto> GrapeTypes { get; set; } 
}

public class ResponseBrandDto
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

public class ResponseRegionDto
{
    public Guid RegionId { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

public class ResponseGrapeTypeDto
{
    public Guid GrapeTypeId { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

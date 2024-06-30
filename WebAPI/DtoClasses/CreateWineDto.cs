namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateWineDto
{
    public string label { get; set; }
    public int Year { get; set; }
    public string? category { get; set; }
    public string? LabelDesignation { get; set; }
    public double? Alcohol { get; set; }
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
    public Guid BrandId { get; set; }
    public Guid RegionId { get; set; }
    public ICollection<Guid> GrapeTypeIds { get; set; }
    public ICollection<Guid> EvaluationIds { get; set; }
    public ICollection<Guid> ParticipantWineIds { get; set; }
}

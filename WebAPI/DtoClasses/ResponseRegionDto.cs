namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseRegionDto
{
    public Guid RegionId { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

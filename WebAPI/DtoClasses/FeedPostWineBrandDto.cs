namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostWineBrandDto
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
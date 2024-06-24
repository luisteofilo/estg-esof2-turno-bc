using ESOF.WebApp.DBLayer.Entities;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateFeedPostDto
{
    public string? Text { get; set; }
    
    public Guid CreatorId { get; set; }
    
    public DateTimeOffset DateTimePost { get; set; }
    
    public IEnumerable<FeedPostMediaDto>? Media { get; set; }
    
    public IEnumerable<FeedPostHashtagDto>? Hashtags { get; set; }
    
    public PostVisibilityType VisibilityType { get; set; }
}
using ESOF.WebApp.DBLayer.Entities;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateFeedPostDto
{
    public string? Text { get; set; }
    
    public Guid CreatorId { get; set; }
    
    public DateTimeOffset DateTimePost { get; set; }
    
    // public IEnumerable<CreateFeedPostMediaDto>? Media { get; set; }
    
    public IEnumerable<CreateFeedPostHashtagDto>? Hashtags { get; set; }
    
    public PostVisibilityType VisibilityType { get; set; }
    
    public Guid? PostEventId { get; set; }
    public Guid? PostWineId { get; set; }
}
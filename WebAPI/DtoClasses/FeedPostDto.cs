namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostDto
{
    public Guid? PostId { get; set; }
    public string? Text { get; set; }
    
    public Guid? CreatorId { get; set; }
    public FeedPostUserDto? Creator { get; set; }
    
    public DateTimeOffset? DateTimePost { get; set; }
    
    public IEnumerable<FeedPostMediaDto>? Media { get; set; }
}
namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseFeedPostDto
{
    public Guid? PostId { get; set; }
    public Guid? CreatorId { get; set; }
    public string? Text { get; set; }
    public DateTimeOffset? DateTimePost { get; set; }
}



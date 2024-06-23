namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateFeedPostDto
{
    public Guid CreatorId { get; set; }
    public string? Text { get; set; }
    public DateTimeOffset DateTimePost { get; set; }
}
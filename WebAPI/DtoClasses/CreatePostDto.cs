namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreatePostDto
{
    public Guid CreatorId { get; set; }
    public string? Text { get; set; }
}
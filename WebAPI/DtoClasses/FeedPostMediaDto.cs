namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostMediaDto
{
    public Guid? MediaId { get; set; }
    
    public Guid? MediaPostId { get; set; }
    public FeedPostDto? MediaPost { get; set; }
    
    public string? Filename { get; set; }
    public string? FileExtension { get; set; }
    
    public byte[]? Data { get; set; }
}
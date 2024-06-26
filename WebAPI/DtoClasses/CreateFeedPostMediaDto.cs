namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateFeedPostMediaDto
{
    public string? Filename { get; set; }
    public string? FileExtension { get; set; }
    
    public byte[]? Data { get; set; }
}
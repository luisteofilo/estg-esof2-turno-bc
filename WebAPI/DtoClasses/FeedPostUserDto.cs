namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostUserDto
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
}
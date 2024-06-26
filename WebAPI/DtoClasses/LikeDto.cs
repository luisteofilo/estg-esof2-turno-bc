namespace ESOF.WebApp.WebAPI.DtoClasses;

public class LikeDto
{
    public Guid LikeId { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
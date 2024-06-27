namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostCommentDto
{
    public Guid CommentId { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public FeedPostUserDto User { get; set; }
}
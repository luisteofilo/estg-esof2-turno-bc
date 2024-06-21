namespace ESOF.WebApp.WebAPI.DtoClasses;

public class EditCommentDto
{
    public Guid CommentId { get; set; }
    public string NewContent { get; set; }
}
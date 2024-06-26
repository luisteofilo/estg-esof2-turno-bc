namespace ESOF.WebApp.DBLayer.DtoClasses;

public class ResponseWineCommentDto
{
    public Guid WineCommentId { get; set; }
    public string Comment  { get; set; }
    public int Evaluation { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid WineId { get; set; }
    public Guid UserId { get; set; }

}
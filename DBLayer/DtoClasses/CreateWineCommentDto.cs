namespace ESOF.WebApp.DBLayer.DtoClasses;

public class CreateWineCommentDto
{
    public Guid WineCommentId { get; set; }
    public string Comment  { get; set; }
    public int Evaluation { get; set; }
    public Guid WineId { get; set; }
    public Guid UserId { get; set; }
}
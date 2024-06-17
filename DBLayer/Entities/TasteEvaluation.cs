namespace ESOF.WebApp.DBLayer.Entities;

public class TasteEvaluation
{
    public Guid TasteEvaluationId { get; set; }
    public Guid UserId { get; set; }
    public Guid? WineId { get; set; }
    public Guid EventId { get; set; }
    public float WineScore { get; set; }
    public User User { get; set; }
    public Wine Wine { get; set; }
    public Event Event { get; set; }
}
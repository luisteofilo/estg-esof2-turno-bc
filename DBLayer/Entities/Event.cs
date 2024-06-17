namespace ESOF.WebApp.DBLayer.Entities;

public class Event
{
    public Guid EventId { get; set; }
    public string EventName { get; set; }
    public ICollection<TasteEvaluation> TasteEvaluations { get; set; }
}
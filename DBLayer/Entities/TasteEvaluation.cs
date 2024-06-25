using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class TasteEvaluation
{
    [Key]
    public Guid TasteEvaluationId { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid WineId { get; set; }
    public Wine Wine { get; set; }
    
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    
    public int WineScore { get; set; }
}
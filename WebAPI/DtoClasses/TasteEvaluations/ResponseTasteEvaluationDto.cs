namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseTasteEvaluationDto
{
    public Guid TasteEvaluationId { get; set; }

    public Guid UserId { get; set; }
    
    public Guid WineId { get; set; }
    
    // TODO: Add the event
    // public Guid EventId { get; set; }
    
    public int WineScore { get; set; }
}
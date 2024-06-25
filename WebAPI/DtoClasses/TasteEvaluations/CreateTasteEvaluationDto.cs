namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateTasteEvaluationDto
{
    public Guid UserId { get; set; }   
    
    public Guid WineId { get; set; }
    
    // TODO: Add the event
    // public Guid EventId { get; set; }
    
    public int WineScore { get; set; }
}
namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateTasteEvaluationDto
{
    public Guid TasteEvaluationId { get; set; }
    public Guid UserId { get; set; }   
    
    public Guid WineId { get; set; }
    
    public Guid EventId { get; set; }
    
    public int WineScore { get; set; }
}
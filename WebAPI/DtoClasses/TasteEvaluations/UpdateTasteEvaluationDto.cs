namespace ESOF.WebApp.WebAPI.DtoClasses;

public class UpdateTasteEvaluationDto
{
    public Guid UserId { get; set; }
    
    public Guid WineId { get; set; }
    
    public Guid EventId { get; set; }
    
    public int WineScore { get; set; }
}
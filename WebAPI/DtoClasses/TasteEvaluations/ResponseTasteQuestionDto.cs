namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseTasteQuestionDto
{
    public Guid TasteQuestionId { get; set; }
    
    public string Question { get; set; }
    
    public Guid TasteQuestionTypeId { get; set; }
    
    public Guid EventId { get; set; }
}
namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateTasteQuestionDto
{
    public string Question { get; set; }
    
    public Guid TasteQuestionTypeId { get; set; }
    
    public Guid EventId { get; set; }
}
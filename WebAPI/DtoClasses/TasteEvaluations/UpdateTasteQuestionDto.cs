namespace ESOF.WebApp.WebAPI.DtoClasses;

public class UpdateTasteQuestionDto
{
    public string Question { get; set; }
    
    public Guid TasteQuestionTypeId { get; set; }
    
    public Guid EventId { get; set; }
}
namespace ESOF.WebApp.WebAPI.DtoClasses;

public class UpdateTasteEvaluationQuestionDto
{
    public Guid TasteEvaluationId { get; set; }
    
    public Guid TasteQuestionId { get; set; }
    
    public String Value { get; set; }
}
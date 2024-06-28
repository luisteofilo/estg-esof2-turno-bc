namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseTasteEvaluationQuestionDto
{
    public Guid TasteEvaluationQuestionId { get; set; }
    
    public Guid TasteEvaluationId { get; set; }
    
    public Guid TasteQuestionId { get; set; }

    public String Value { get; set; }
}
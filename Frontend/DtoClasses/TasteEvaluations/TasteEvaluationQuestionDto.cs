namespace Frontend.DtoClasses;

public class TasteEvaluationQuestionDto
{
    public Guid TasteEvaluationQuestionId { get; set; }
    
    public Guid TasteEvaluationId { get; set; }
    
    public Guid TasteQuestionId { get; set; }
    
    public String Value { get; set; }
}
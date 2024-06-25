namespace ESOF.WebApp.DBLayer.Entities;

public class TasteEvaluationQuestion
{
    public Guid TasteEvaluationQuestionId { get; set; }
    public Guid TasteEvaluationId { get; set; }
    public Guid TasteQuestionId { get; set; }
    public Guid? TasteQuestionOptionId { get; set; } 
    public string Value { get; set; }

    public TasteEvaluation TasteEvaluation { get; set; }
    public TasteQuestion TasteQuestion { get; set; }
    public TasteQuestionOption TasteQuestionOption { get; set; } 
}

using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class TasteEvaluationQuestion
{
    [Key]
    public Guid TasteEvaluationQuestionId { get; set; }
    
    public Guid TasteEvaluationId { get; set; }
    public TasteEvaluation TasteEvaluation { get; set; }
    
    public Guid TasteQuestionId { get; set; }
    public TasteQuestion TasteQuestion { get; set; }
    
    public String Value { get; set; }
}
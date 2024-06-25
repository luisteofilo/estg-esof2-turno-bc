using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class TasteQuestion
{
    [Key]
    public Guid TasteQuestionId { get; set; }
    public string Questions { get; set; }
    public Guid QuestionTypeId { get; set; }
    public Guid EventId { get; set; }
    public TasteQuestionsType QuestionType { get; set; }
    public Event Event { get; set; }
    public ICollection<TasteQuestionOption> Options { get; set; }
    public ICollection<TasteEvaluationQuestion> TasteEvaluationQuestions { get; set; }
}
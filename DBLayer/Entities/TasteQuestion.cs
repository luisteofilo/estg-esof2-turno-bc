using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class TasteQuestion
{
    [Key]
    public Guid TasteQuestionId { get; set; }
    
    public string Question { get; set; }
    
    public Guid TasteQuestionTypeId { get; set; }
    public TasteQuestionType TasteQuestionType { get; set; }
    
    // TODO: Add the event
    // public Guid EventId { get; set; }
    // public Event Event { get; set; }
}
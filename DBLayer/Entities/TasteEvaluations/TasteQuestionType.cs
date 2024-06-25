using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class TasteQuestionType
{
    [Key]
    public Guid TasteQuestionTypeId { get; set; }
    
    public string Type { get; set; }
}
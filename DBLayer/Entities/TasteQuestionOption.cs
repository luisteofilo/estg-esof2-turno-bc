namespace ESOF.WebApp.DBLayer.Entities;

public class TasteQuestionOption
{
    public Guid TasteQuestionOptionId { get; set; }
    public string OptionText { get; set; }
    public Guid TasteQuestionId { get; set; }

    public TasteQuestion TasteQuestion { get; set; }
}
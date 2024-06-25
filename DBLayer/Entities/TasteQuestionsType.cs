namespace ESOF.WebApp.DBLayer.Entities;

public class TasteQuestionsType
{
    public Guid TasteQuestionsTypeId { get; set; }
    public string Type { get; set; }
    public ICollection<TasteQuestion> TasteQuestions { get; set; }
}
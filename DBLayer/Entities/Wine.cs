namespace ESOF.WebApp.DBLayer.Entities;

public class Wine
{
    public Guid WineId { get; set; }
    public string WineName { get; set; }
    public ICollection<TasteEvaluation> TasteEvaluations { get; set; }
}
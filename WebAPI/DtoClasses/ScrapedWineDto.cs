namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ScrapedWineDto
{
    public Guid ScrapedWineId { get; set; }

    public string Url { get; set; }

    public string Label { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
}

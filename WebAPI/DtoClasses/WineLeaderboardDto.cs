namespace ESOF.WebApp.WebAPI.DtoClasses;

public class WineLeaderboardDto
{
    public Guid WineId { get; set; }
    public string Label { get; set; } = string.Empty;
    public double AverageScore { get; set; }
    public int TotalEvaluations { get; set; }
    public int EventsParticipated { get; set; }
    public string RegionName { get; set; } = string.Empty;
}
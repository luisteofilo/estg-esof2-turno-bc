namespace ESOF.WebApp.WebAPI.DtoClasses;

public class UserLeaderboardDto
{
    public Guid UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public int EventsParticipated { get; set; }
    public double AverageEvaluationScore { get; set; }
    public double LowestEvaluationScore { get; set; }
    public double HighestEvaluationScore { get; set; }
    public int TotalEvaluations { get; set; }
}
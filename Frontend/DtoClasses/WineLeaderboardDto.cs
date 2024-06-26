namespace Frontend.DtoClasses;

using System;

public class WineLeaderboardDto
{
    public Guid WineId { get; set; }
    public string Label { get; set; }
    public double AverageScore { get; set; }
    public int TotalEvaluations { get; set; }
}
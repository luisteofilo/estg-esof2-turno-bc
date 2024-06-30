namespace ESOF.WebApp.WebAPI.Services;

using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.DBLayer.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class UserLeaderboardService
{
    private readonly ApplicationDbContext _context;

    public UserLeaderboardService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<UserLeaderboardDto> GetUserLeaderboard()
    {
        var userLeaderboard = _context.TasteEvaluations
            .Include(te => te.User)
            .GroupBy(te => new { te.User.UserId, te.User.Email })
            .Select(g => new UserLeaderboardDto
            {
                UserId = g.Key.UserId,
                Email = g.Key.Email,
                EventsParticipated = g.Select(te => te.EventId).Distinct().Count(),
                AverageEvaluationScore = g.Average(te => te.WineScore),
                LowestEvaluationScore = g.Min(te => te.WineScore),
                HighestEvaluationScore = g.Max(te => te.WineScore),
                TotalEvaluations = g.Count()
            })
            .OrderByDescending(dto => dto.TotalEvaluations)
            .ToList();

        return userLeaderboard;
    }
}
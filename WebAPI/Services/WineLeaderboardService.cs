namespace ESOF.WebApp.WebAPI.Services;

using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.DBLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class WineLeaderboardService
{
    private readonly ApplicationDbContext _context;

    public WineLeaderboardService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<WineLeaderboardDto> GetWineLeaderboard()
    {
        var leaderboard = _context.TasteEvaluations
            .Include(te => te.Wine)
            .ThenInclude(w => w.Region)
            .GroupBy(te => new { te.Wine.WineId, te.Wine.label, te.Wine.Region.Name })
            .Select(g => new WineLeaderboardDto
            {
                WineId = g.Key.WineId,
                Label = g.Key.label,
                AverageScore = g.Average(te => te.WineScore),
                TotalEvaluations = g.Count(),
                EventsParticipated = g.Select(te => te.EventId).Distinct().Count(),
                RegionName = g.Key.Name
            })
            .OrderByDescending(dto => dto.AverageScore)
            .ToList();

        return leaderboard;
    }
    
    public List<WineLeaderboardDto> GetWineLeaderboardByRegion(Guid regionId)
    {
        var leaderboard = _context.TasteEvaluations
            .Include(te => te.Wine)
            .ThenInclude(w => w.Region)
            .Where(te => te.Wine.RegionId == regionId)
            .GroupBy(te => new { te.Wine.WineId, te.Wine.label, te.Wine.Region.Name })
            .Select(g => new WineLeaderboardDto
            {
                WineId = g.Key.WineId,
                Label = g.Key.label,
                AverageScore = g.Average(te => te.WineScore),
                TotalEvaluations = g.Count(),
                EventsParticipated = g.Select(te => te.EventId).Distinct().Count(),
                RegionName = g.Key.Name
            })
            .OrderByDescending(dto => dto.AverageScore)
            .ToList();

        return leaderboard;
    }
}
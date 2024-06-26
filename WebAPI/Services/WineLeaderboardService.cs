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
        try
        {
            var leaderboard = _context.TasteEvaluations
                .Include(te => te.Wine)
                .GroupBy(te => te.Wine)
                .Select(g => new WineLeaderboardDto
                {
                    WineId = g.Key.WineId,
                    Label = g.Key.label,
                    AverageScore = g.Average(te => te.WineScore),
                    TotalEvaluations = g.Count()
                })
                .OrderByDescending(l => l.AverageScore)
                .ToList();

            return leaderboard;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving the wine leaderboard.", ex);
        }
    }
}
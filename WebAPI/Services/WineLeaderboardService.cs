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
            .GroupBy(te => te.Wine)
            .Select(g => new WineLeaderboardDto
            {
                WineId = g.Key.WineId,
                Label = g.Key.label,
                AverageScore = g.Average(te => te.WineScore),
                TotalEvaluations = g.Count()
            })
            .OrderByDescending(dto => dto.AverageScore)
            .ToList();

        return leaderboard;
    }
}
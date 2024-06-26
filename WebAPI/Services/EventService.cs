using ESOF.WebApp.WebAPI.DtoClasses;
using WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class EventService
{
    private readonly ApplicationDbContext _context;

    public EventService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Event>> SearchEvents(
        string eventName,
        string participantName,
        string wineName,
        string regionName,
        string brandName,
        Guid? grapeTypeId)
    {
        var query = _context.Events
            .Include(e => e.EventParticipants)
            .Include(e => e.Wines)
            .ThenInclude(w => w.Brand)
            .Include(e => e.Wines)
            .ThenInclude(w => w.WineGrapeTypeLinks)
            .ThenInclude(wgt => wgt.GrapeType)
            .AsQueryable();

        if (!string.IsNullOrEmpty(eventName))
        {
            query = query.Where(e => e.Name.Contains(eventName));
        }

        if (!string.IsNullOrEmpty(participantName))
        {
            query = query.Where(e => e.EventParticipants.Any(p => p.User.Email.Contains(participantName)));
        }

        if (!string.IsNullOrEmpty(brandName))
        {
            query = query.Where(e => e.Wines.Any(w => w.Brand.Name.Contains(brandName)));
        }

        if (!string.IsNullOrEmpty(wineName))
        {
            query = query.Where(e => e.Wines.Any(w => w.label.Contains(wineName)));
        }

        if (grapeTypeId.HasValue)
        {
            query = query.Where(e => e.Wines.Any(w => w.WineGrapeTypeLinks.Any(wgt => wgt.GrapeType.GrapeTypeId == grapeTypeId)));
        }

        if (!string.IsNullOrEmpty(regionName))
        {
            query = query.Where(e => e.Wines.Any(w => w.Region.Name.Contains(regionName)));
        }
        return await query.ToListAsync();
    }
}
using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class InteractionService
{
    private readonly ApplicationDbContext _context;

    public InteractionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ResponseInteractionDto> GetAllInteractions()
    {
        return _context.Interaction
            .Select(i => new ResponseInteractionDto
            {
                InteractionLinkId = i.InteractionLinkId,
                UserId = i.UserId,
                WineId = i.WineId,
                InteractionType = i.InteractionType
            })
            .ToList();
    }

    public ResponseInteractionDto GetInteractionById(Guid userId, Guid wineId)
    {
        var interaction = _context.Interaction
            .FirstOrDefault(i => i.UserId == userId && i.WineId == wineId);

        if (interaction == null)
        {
            return new ResponseInteractionDto();
        }

        return new ResponseInteractionDto
        {
            InteractionLinkId = interaction.InteractionLinkId,
            UserId = interaction.UserId,
            WineId = interaction.WineId,
            InteractionType = interaction.InteractionType
        };

    }

    public ResponseInteractionDto CreateInteraction(CreateInteractionDto createInteractionDto)
    {
        var interaction = new Interaction
        {
            InteractionLinkId = Guid.NewGuid(),
            UserId = createInteractionDto.UserId,
            WineId = createInteractionDto.WineId,
            InteractionType = createInteractionDto.InteractionType
        };

        _context.Interaction.Add(interaction);
        _context.SaveChanges();

        return new ResponseInteractionDto
        {
            InteractionLinkId = interaction.InteractionLinkId,
            UserId = interaction.UserId,
            WineId = interaction.WineId,
            InteractionType = interaction.InteractionType
        };

    }

    public ResponseInteractionDto UpdateInteraction(Guid userId, Guid wineId, UpdateInteractionDto updateInteractionDto)
    {
        var interaction = _context.Interaction
            .FirstOrDefault(i => i.UserId == userId && i.WineId == wineId);

        if (interaction == null)
        {
            throw new ArgumentException("Interaction not found");
        }

        interaction.InteractionType = updateInteractionDto.InteractionType;
        _context.SaveChanges();

        return new ResponseInteractionDto
        {
            InteractionLinkId = interaction.InteractionLinkId,
            UserId = interaction.UserId,
            WineId = interaction.WineId,
            InteractionType = interaction.InteractionType
        };

    }

    public void DeleteInteraction(Guid userId, Guid wineId)
    {
        var interaction = _context.Interaction
            .FirstOrDefault(i => i.UserId == userId && i.WineId == wineId);

        if (interaction == null)
        {
            throw new ArgumentException("Interaction not found");
        }

        _context.Interaction.Remove(interaction);
        _context.SaveChanges();

    }
}



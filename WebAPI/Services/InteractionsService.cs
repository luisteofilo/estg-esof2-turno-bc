using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class InteractionsService
{
    private readonly ApplicationDbContext _context;

    public InteractionsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ResponseInteractionDto> GetAllInteractions()
    {
        // Implemente a lógica para obter todas as interações
    }

    public ResponseInteractionDto GetInteractionById(Guid id)
    {
        // Implemente a lógica para obter uma interação por ID
    }

    public ResponseInteractionDto CreateInteraction(CreateInteractionDto createInteractionDto)
    {
        // Implemente a lógica para criar uma nova interação
    }

    public ResponseInteractionDto UpdateInteraction(Guid id, UpdateInteractionDto updateInteractionDto)
    {
        // Implemente a lógica para atualizar uma interação existente
    }

    public void DeleteInteraction(Guid id)
    {
        // Implemente a lógica para deletar uma interação
    }
}

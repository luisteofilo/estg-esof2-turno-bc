using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class GrapeTypeService
{
    private readonly ApplicationDbContext _context;

    public GrapeTypeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ResponseGrapeTypeDto> GetAllGrapeTypes()
    {
        try
        {
            return _context.GrapeTypes.Select(grapeType => new ResponseGrapeTypeDto
            {
                GrapeTypeId = grapeType.GrapeTypeId,
                Name = grapeType.Name,
                CreatedAt = grapeType.CreatedAt,
                UpdatedAt = grapeType.UpdatedAt
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving grape types.", ex);
        }
    }

    public ResponseGrapeTypeDto GetGrapeTypeById(Guid id)
    {
        var grapeType = _context.GrapeTypes.Find(id);
        if (grapeType == null)
        {
            throw new ArgumentException("Grape type not found.");
        }

        return new ResponseGrapeTypeDto
        {
            GrapeTypeId = grapeType.GrapeTypeId,
            Name = grapeType.Name,
            CreatedAt = grapeType.CreatedAt,
            UpdatedAt = grapeType.UpdatedAt
        };
    }

    public ResponseGrapeTypeDto CreateGrapeType(CreateGrapeTypeDto createGrapeTypeDto)
    {
        try
        {
            var grapeType = new GrapeType
            {
                Name = createGrapeTypeDto.Name
            };

            _context.GrapeTypes.Add(grapeType);
            _context.SaveChanges();

            return new ResponseGrapeTypeDto
            {
                GrapeTypeId = grapeType.GrapeTypeId,
                Name = grapeType.Name,
                CreatedAt = grapeType.CreatedAt,
                UpdatedAt = grapeType.UpdatedAt
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while creating the grape type.", ex);
        }
    }

    public ResponseGrapeTypeDto UpdateGrapeType(Guid id, UpdateGrapeTypeDto updateGrapeTypeDto)
    {
        var grapeType = _context.GrapeTypes.Find(id);

        if (grapeType == null)
        {
            throw new ArgumentException("Grape type not found.");
        }

        grapeType.Name = updateGrapeTypeDto.Name?? grapeType.Name;
        grapeType.UpdatedAt = DateTimeOffset.UtcNow;

        _context.SaveChanges();

        return new ResponseGrapeTypeDto
        {
            GrapeTypeId = grapeType.GrapeTypeId,
            Name = grapeType.Name,
            CreatedAt = grapeType.CreatedAt,
            UpdatedAt = grapeType.UpdatedAt
        };
    }

    public void DeleteGrapeType(Guid id)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var grapeType = _context.GrapeTypes.Find(id);

                if (grapeType == null)
                {
                    throw new Exception($"Cannot find the resource");
                }

                grapeType.DeletedAt = DateTimeOffset.UtcNow;
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
    
    public IEnumerable<GrapeType> GetGrapeTypesByIds(ICollection<Guid> grapeTypeIds)
    {
        return _context.GrapeTypes.Where(gt => grapeTypeIds.Contains(gt.GrapeTypeId)).ToList();
    }
}
using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class RegionService
{
    private readonly ApplicationDbContext _context;

    public RegionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ResponseRegionDto> GetAllRegions()
    {
        try
        {
            return _context.Regions.Select(region => new ResponseRegionDto
            {
                RegionId = region.RegionId,
                Name = region.Name,
                CreatedAt = region.CreatedAt,
                UpdatedAt = region.UpdatedAt
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving regions.", ex);
        }
    }

    public ResponseRegionDto GetRegionById(Guid id)
    {
        var region = _context.Regions.Find(id);
        if (region == null)
        {
            throw new ArgumentException("Region not found.");
        }

        return new ResponseRegionDto
        {
            RegionId = region.RegionId,
            Name = region.Name,
            CreatedAt = region.CreatedAt,
            UpdatedAt = region.UpdatedAt
        };
    }

    public ResponseRegionDto CreateRegion(RegionDto regionDto)
    {
        try
        {
            var region = new Region
            {
                Name = regionDto.Name
            };

            _context.Regions.Add(region);
            _context.SaveChanges();

            return new ResponseRegionDto
            {
                RegionId = region.RegionId,
                Name = region.Name,
                CreatedAt = region.CreatedAt,
                UpdatedAt = region.UpdatedAt
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while creating the region.", ex);
        }
    }

    public ResponseRegionDto UpdateRegion(Guid id, RegionDto regionDto)
    {
        var region = _context.Regions.Find(id);

        if (region == null)
        {
            throw new ArgumentException("Region not found.");
        }

        region.Name = regionDto.Name;
        region.UpdatedAt = DateTimeOffset.UtcNow;

        _context.SaveChanges();

        return new ResponseRegionDto
        {
            RegionId = region.RegionId,
            Name = region.Name,
            CreatedAt = region.CreatedAt,
            UpdatedAt = region.UpdatedAt
        };
    }

    public void DeleteRegion(Guid id)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var region = _context.Regions.Find(id);

                if (region == null)
                {
                    throw new Exception($"Cannot find the resource");
                }

                region.DeletedAt = DateTimeOffset.UtcNow;
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
}
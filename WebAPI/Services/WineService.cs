using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class WineService
{
    private readonly ApplicationDbContext _context;
    private readonly GrapeTypeService _grapeTypeService;
    private readonly BrandService _brandService;
    private readonly RegionService _regionService;

    public WineService(ApplicationDbContext context)
    {
        _context = context;
        _grapeTypeService = new GrapeTypeService (context) ;
        _brandService = new BrandService(context);
        _regionService = new RegionService(context);
    }

    public List<ResponseWineDto> GetAllWines()
    {
        try
        {
            var wines = _context.Wines
                .Include(w => w.WineGrapeTypeLinks) 
                .ThenInclude(wgtl => wgtl.GrapeType) 
                .ToList();

            return wines.Select(wine => new ResponseWineDto
            {
                WineId = wine.WineId,
                Label = wine.label,
                Year = wine.Year,
                Category = wine.category,
                LabelDesignation = wine.LabelDesignation,
                Alcohol = wine.Alcohol,
                MinimumPrice = wine.MinimumPrice,
                MaximumPrice = wine.MaximumPrice,
                CreatedAt = wine.CreatedAt,
                UpdatedAt = wine.UpdatedAt,
                BrandId = wine.BrandId,
                RegionId = wine.RegionId,
                GrapeTypeIds = wine.WineGrapeTypeLinks.Select(link => link.GrapeTypeId)
                
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving wines.", ex); 
        }
    }


    public ResponseWineDto GetWineById(Guid id)
    {
        try
        {
            var wine = _context.Wines
                .Include(w => w.Brand)
                .Include(w => w.Region) 
                .Include(w => w.WineGrapeTypeLinks)
                .ThenInclude(wgtl => wgtl.GrapeType)
                .FirstOrDefault(w => w.WineId == id);

            if (wine == null)
            {
                throw new ArgumentException("Wine not found.");
            }

            return new ResponseWineDto
            {
                WineId = wine.WineId,
                Label = wine.label,
                Year = wine.Year,
                Category = wine.category,
                LabelDesignation = wine.LabelDesignation,
                Alcohol = wine.Alcohol,
                MinimumPrice = wine.MinimumPrice,
                MaximumPrice = wine.MaximumPrice,
                CreatedAt = wine.CreatedAt,
                UpdatedAt = wine.UpdatedAt,
                BrandId = wine.BrandId,
                RegionId = wine.RegionId,
                Brand = new ResponseBrandDto 
                {
                    BrandId = wine.Brand.BrandId,
                    Name = wine.Brand.Name,
                    Description = wine.Brand.Description,
                    CreatedAt = wine.Brand.CreatedAt,
                    UpdatedAt = wine.Brand.UpdatedAt
                },
                Region = new ResponseRegionDto
                {
                    RegionId = wine.Region.RegionId,
                    Name = wine.Region.Name,
                    CreatedAt = wine.Region.CreatedAt,
                    UpdatedAt = wine.Region.UpdatedAt
                },
                GrapeTypes = wine.WineGrapeTypeLinks
                    .Select(link => new ResponseGrapeTypeDto
                    {
                        GrapeTypeId = link.GrapeType.GrapeTypeId,
                        Name = link.GrapeType.Name,
                        CreatedAt = link.GrapeType.CreatedAt,
                        UpdatedAt = link.GrapeType.UpdatedAt
                    })
                    .ToList()
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving wine with ID {id}.", ex);
        }
    }


    public ResponseWineDto CreateWine(Wine wine, ICollection<Guid> grapeTypeIds, Guid brandId, Guid regionId)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                if (string.IsNullOrWhiteSpace(wine.label) || wine.Year == 0)
                {
                    throw new ArgumentException("Label and Year are required fields.");
                }
            
                if (grapeTypeIds == null || !grapeTypeIds.Any())
                {
                    throw new ArgumentException("At least one GrapeTypeId is required.");
                }
                
                var brand = _context.Brands.Find(brandId);
                if (brand == null)
                {
                    throw new ArgumentException("Brand not found.");
                }
                wine.Brand = brand; 

                var region = _context.Regions.Find(regionId);
                if (region == null)
                {
                    throw new ArgumentException("Region not found.");
                }
                wine.Region = region;
                
                var grapeTypes = _grapeTypeService.GetGrapeTypesByIds(grapeTypeIds); 

                if (grapeTypes == null || !grapeTypes.Any())
                {
                    throw new ArgumentException("Grape types not found.");
                }

                wine.WineGrapeTypeLinks = grapeTypeIds
                    .Where(grapeTypeId => grapeTypes.Any(gt => gt.GrapeTypeId == grapeTypeId))
                    .Select(grapeTypeId => new WineGrapeTypeLink
                    {
                        WineId = wine.WineId, 
                        GrapeTypeId = grapeTypeId
                    })
                    .ToList();

                _context.Wines.Add(wine);
                _context.SaveChanges();
                transaction.Commit();

                    return new ResponseWineDto
                    {
                        WineId = wine.WineId,
                        Label = wine.label,
                        Year = wine.Year,
                        Category = wine.category,
                        LabelDesignation = wine.LabelDesignation,
                        Alcohol = wine.Alcohol,
                        MinimumPrice = wine.MinimumPrice,
                        MaximumPrice = wine.MaximumPrice,
                        CreatedAt = wine.CreatedAt,
                        UpdatedAt = wine.UpdatedAt,
                        BrandId = wine.BrandId,
                        RegionId = wine.RegionId,
                        GrapeTypeIds = wine.WineGrapeTypeLinks.Select(link => link.GrapeTypeId).ToList() 
                    };
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while creating the wine. Please try again later.", ex);
                }
                catch (ArgumentException ex)
                {
                    transaction.Rollback();
                    throw; 
                }
        }
    }


public ResponseWineDto UpdateWine(Guid id, UpdateWineDto updateWineDto)
{
    using (var transaction = _context.Database.BeginTransaction())
    {
        try
        {
            var wine = _context.Wines
                .Include(w => w.WineGrapeTypeLinks)
                .ThenInclude(wgtl => wgtl.GrapeType)
                .FirstOrDefault(w => w.WineId == id);

            if (wine == null)
            {
                throw new ArgumentException("Wine not found.");
            }

            wine.label = updateWineDto.Label ?? wine.label;
            wine.Year = updateWineDto.Year ?? wine.Year;
            wine.category = updateWineDto.Category ?? wine.category;
            wine.LabelDesignation = updateWineDto.LabelDesignation ?? wine.LabelDesignation;
            wine.Alcohol = updateWineDto.Alcohol ?? wine.Alcohol;
            wine.MinimumPrice = updateWineDto.MinimumPrice ?? wine.MinimumPrice;
            wine.MaximumPrice = updateWineDto.MaximumPrice ?? wine.MaximumPrice;
            wine.UpdatedAt = DateTimeOffset.UtcNow;

            if (updateWineDto.BrandId.HasValue)
            {
                var brand = _context.Brands.Find(updateWineDto.BrandId.Value);
                if (brand == null)
                {
                    throw new ArgumentException("Brand not found.");
                }
                wine.Brand = brand;
                wine.BrandId = updateWineDto.BrandId.Value;
            }

            if (updateWineDto.RegionId.HasValue)
            {
                var region = _context.Regions.Find(updateWineDto.RegionId.Value);
                if (region == null)
                {
                    throw new ArgumentException("Region not found.");
                }
                wine.Region = region;
                wine.RegionId = updateWineDto.RegionId.Value;
            }

            if (updateWineDto.GrapeTypeIds != null && updateWineDto.GrapeTypeIds.Any())
            {
                _context.WineGrapeTypeLinks.RemoveRange(wine.WineGrapeTypeLinks);

                var grapeTypes = _grapeTypeService.GetGrapeTypesByIds(updateWineDto.GrapeTypeIds);

                if (grapeTypes == null || !grapeTypes.Any())
                {
                    throw new ArgumentException("No grape types found for the provided IDs.");
                }

                wine.WineGrapeTypeLinks = updateWineDto.GrapeTypeIds
                    .Where(grapeTypeId => grapeTypes.Any(gt => gt.GrapeTypeId == grapeTypeId))
                    .Select(grapeTypeId => new WineGrapeTypeLink
                    {
                        WineId = wine.WineId,
                        GrapeTypeId = grapeTypeId
                    })
                    .ToList();
            }
            
            _context.SaveChanges();
            transaction.Commit();

            return new ResponseWineDto
            {
                WineId = wine.WineId,
                Label = wine.label,
                Year = wine.Year,
                Category = wine.category,
                LabelDesignation = wine.LabelDesignation,
                Alcohol = wine.Alcohol,
                MinimumPrice = wine.MinimumPrice,
                MaximumPrice = wine.MaximumPrice,
                CreatedAt = wine.CreatedAt,
                UpdatedAt = wine.UpdatedAt,
                BrandId = wine.BrandId,
                RegionId = wine.RegionId,
                GrapeTypeIds = wine.WineGrapeTypeLinks.Select(link => link.GrapeTypeId)
            };
        }
        catch (DbUpdateException ex)
        {
            transaction.Rollback();
            throw new Exception("An error occurred while updating the wine.", ex);
        }
    }
}
    

    public void DeleteWine(Guid id)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var wine = _context.Wines
                    .Include(w => w.WineGrapeTypeLinks) 
                    .FirstOrDefault(w => w.WineId == id); 

                if (wine == null)
                {
                    throw new ArgumentException("Wine not found.");
                }

                
                _context.WineGrapeTypeLinks.RemoveRange(wine.WineGrapeTypeLinks);

               
                wine.DeletedAt = DateTimeOffset.UtcNow;
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                transaction.Rollback();
                throw new Exception("Concurrency conflict occurred while deleting the wine.", ex); 
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                throw new Exception("An error occurred while deleting the wine.", ex); 
            }
        }
    }

}
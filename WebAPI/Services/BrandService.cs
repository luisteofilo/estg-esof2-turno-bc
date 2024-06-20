using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class BrandService
{
    private readonly ApplicationDbContext _context;

    public BrandService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ResponseBrandDto> GetAllBrands()
    {
        try
        {
            return _context.Brands.Select(brand => new ResponseBrandDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Description = brand.Description,
                CreatedAt = brand.CreatedAt,
                UpdatedAt = brand.UpdatedAt
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving brands.", ex);
        }
    }

    public ResponseBrandDto GetBrandById(Guid id)
    {
        var brand = _context.Brands.Find(id);
        if (brand == null)
        {
            throw new ArgumentException("Brand not found.");
        }

        return new ResponseBrandDto
        {
            BrandId = brand.BrandId,
            Name = brand.Name,
            Description = brand.Description,
            CreatedAt = brand.CreatedAt,
            UpdatedAt = brand.UpdatedAt
        };
    }

    public ResponseBrandDto CreateBrand(CreateBrandDto createBrandDto)
    {
        try
        {
            var brand = new Brand
            {
                Name = createBrandDto.Name,
                Description = createBrandDto.Description
            };

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return new ResponseBrandDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Description = brand.Description,
                CreatedAt = brand.CreatedAt,
                UpdatedAt = brand.UpdatedAt
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while creating the brand.", ex);
        }
    }

    public ResponseBrandDto UpdateBrand(Guid id, UpdateBrandDto updateBrandDto)
    {
        var brand = _context.Brands.Find(id);

        if (brand == null)
        {
            throw new ArgumentException("Brand not found.");
        }

        brand.Name = updateBrandDto.Name?? brand.Name;
        brand.Description = updateBrandDto.Description?? brand.Description;
        brand.UpdatedAt = DateTimeOffset.UtcNow;

        _context.SaveChanges();

        return new ResponseBrandDto
        {
            BrandId = brand.BrandId,
            Name = brand.Name,
            Description = brand.Description,
            CreatedAt = brand.CreatedAt,
            UpdatedAt = brand.UpdatedAt
        };
    }

    public void DeleteBrand(Guid id)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var brand = _context.Brands.Find(id);

                if (brand == null)
                {
                    throw new ArgumentException("Brand not found.");
                }

                brand.DeletedAt = DateTimeOffset.UtcNow; 
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
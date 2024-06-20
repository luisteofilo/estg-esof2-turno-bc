using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly BrandService _brandService;

    public BrandController()
    {
        _brandService =  new BrandService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseBrandDto>> GetAllBrands()
    {
        try
        {
            return Ok(_brandService.GetAllBrands());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseBrandDto> GetBrandById(Guid id)
    {
        try
        {
            return Ok(_brandService.GetBrandById(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<ResponseBrandDto> CreateBrand([FromBody] CreateBrandDto createBrandDto)
    {
        try
        {
            var createdBrand = _brandService.CreateBrand(createBrandDto);
            return CreatedAtAction(nameof(GetBrandById), new { id = createdBrand.BrandId }, createdBrand);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public ActionResult<ResponseBrandDto> UpdateBrand(Guid id, [FromBody] UpdateBrandDto updateBrandDto)
    {
        try
        {
            return Ok(_brandService.UpdateBrand(id, updateBrandDto));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public ActionResult DeleteBrand(Guid id)
    {
        try
        {
            _brandService.DeleteBrand(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
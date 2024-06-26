using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;

[Route("api/region")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly RegionService _regionService;

    public RegionController()
    {
        _regionService = new RegionService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseRegionDto>> GetAllRegions()
    {
        try
        {
            return _regionService.GetAllRegions();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseRegionDto> GetRegionById(Guid id)
    {
        try
        {
            return _regionService.GetRegionById(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<ResponseRegionDto> CreateRegion([FromBody] CreateRegionDto createRegionDto)
    {
        try
        {
            var createdRegion = _regionService.CreateRegion(createRegionDto);
            return CreatedAtAction(nameof(GetRegionById), new { id = createdRegion.RegionId }, createdRegion);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpPut("update")]
    public ActionResult<ResponseRegionDto> UpdateRegion(Guid id, [FromBody] UpdateRegionDto updateRegionDto)
    {
        try
        {
            var updatedRegion = _regionService.UpdateRegion(id, updateRegionDto);
            return Ok(updatedRegion);
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
    public ActionResult DeleteRegion(Guid id)
    {
        try
        {
            _regionService.DeleteRegion(id);
            return NoContent();
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
}
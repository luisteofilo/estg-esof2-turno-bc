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
            return NotFound(ex.Message); // Retorna NotFound se a região não for encontrada
        }
    }

    [HttpPost("store")]
    public ActionResult<ResponseRegionDto> CreateRegion([FromBody] RegionDto regionDto)
    {
        try
        {
            var createdRegion = _regionService.CreateRegion(regionDto);
            return CreatedAtAction(nameof(GetRegionById), new { id = createdRegion.RegionId }, createdRegion);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Retorna BadRequest em caso de erro geral
        }
    }

    [HttpPut("update")]
    public ActionResult<ResponseRegionDto> UpdateRegion(Guid id, [FromBody] RegionDto regionDto)
    {
        try
        {
            var updatedRegion = _regionService.UpdateRegion(id, regionDto);
            return Ok(updatedRegion);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message); // Retorna NotFound se a região não for encontrada
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Retorna BadRequest em caso de erro geral
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
            return NotFound(ex.Message); // Retorna NotFound se a região não for encontrada
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Retorna BadRequest em caso de erro geral
        }
    }
}
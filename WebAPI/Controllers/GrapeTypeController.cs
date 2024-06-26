using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;

[Route("api/grape")]
[ApiController]
public class GrapeTypeController : ControllerBase
{
    private readonly GrapeTypeService _grapeTypeService;

    public GrapeTypeController() 
    {
        _grapeTypeService = new GrapeTypeService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseGrapeTypeDto>> GetAllGrapeTypes() 
    {
        try
        {
            return _grapeTypeService.GetAllGrapeTypes();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseGrapeTypeDto> GetGrapeTypeById(Guid id) 
    {
        try
        {
            return _grapeTypeService.GetGrapeTypeById(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message); 
        }
    }

    [HttpPost("store")]
    public ActionResult<ResponseGrapeTypeDto> CreateGrapeType([FromBody] CreateGrapeTypeDto createGrapeTypeDto)
    {
        try
        {
            var createdGrapeType = _grapeTypeService.CreateGrapeType(createGrapeTypeDto);
            return CreatedAtAction(nameof(GetGrapeTypeById), new { id = createdGrapeType.GrapeTypeId }, createdGrapeType);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpPut("update")]
    public ActionResult<ResponseGrapeTypeDto> UpdateGrapeType(Guid id, [FromBody] UpdateGrapeTypeDto updateGrapeTypeDto)
    {
        try
        {
            var updatedGrapeType = _grapeTypeService.UpdateGrapeType(id, updateGrapeTypeDto);
            return Ok(updatedGrapeType);
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
    public ActionResult DeleteGrapeType(Guid id)
    {
        try
        {
            _grapeTypeService.DeleteGrapeType(id);
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
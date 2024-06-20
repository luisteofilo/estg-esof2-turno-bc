using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ESOF.WebApp.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class WineController : ControllerBase
{
    private readonly WineService _wineService;

    public WineController()
    {
        _wineService = new WineService(new ApplicationDbContext());
    }
    
    [HttpGet("index")]
    public ActionResult<List<ResponseWineDto>> GetAllWines()
    {
        return _wineService.GetAllWines();
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseWineDto> GetWineById(Guid id)
    {
        try
        {
            return _wineService.GetWineById(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<Wine> CreateWine([FromBody] CreateWineDto createWineDto)
    {
        try
        {
            var createdWine = _wineService.CreateWine(createWineDto);
            return CreatedAtAction(nameof(GetWineById), new { id = createdWine.WineId }, createdWine);
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


    [HttpPut("update")]
    public ActionResult<ResponseWineDto> UpdateWine(Guid id,UpdateWineDto updateWineDto)
    {
        try
        {
            var updatedWine = _wineService.UpdateWine(id, updateWineDto);
            return Ok(updatedWine); 
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public ActionResult DeleteWine(Guid id)
    {
        try
        {
            _wineService.DeleteWine(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
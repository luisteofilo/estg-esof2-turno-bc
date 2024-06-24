using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.AspNetCore.Mvc;
namespace ESOF.WebApp.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class BlindEventController : ControllerBase
{
    private readonly BlindEventService _blindEventService;

    public BlindEventController()
    {
        _blindEventService = new BlindEventService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseBlindEventDto>> GetAllBlindEvents()
    {
        return _blindEventService.GetAllBlindEvents();
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseBlindEventDto> GetBlindEventById(Guid id)
    {
        try
        {
            return _blindEventService.GetBlindEventById(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<BlindEvent> CreateBlindEvent([FromBody] CreateBlindEventDto createBlindEventDto)
    {
        try
        {
            var createdBlindEvent = _blindEventService.CreateBlindEvent(createBlindEventDto);
            return CreatedAtAction(nameof(GetBlindEventById), new { id = createdBlindEvent.BlindEventId }, createdBlindEvent);
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
    public ActionResult DeleteBlindEvent(Guid id)
    {
        try
        {
            _blindEventService.DeleteBlindEvent(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
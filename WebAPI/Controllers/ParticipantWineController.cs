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
public class ParticipantWineController : ControllerBase
{
    private readonly ParticipantWineService _participantWineService;

    public ParticipantWineController()
    {
        _participantWineService = new ParticipantWineService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseParticipantWineDto>> GetAllParticipantWines()
    {
        return _participantWineService.GetAllParticipantWines();
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseParticipantWineDto> GetParticipantWineById(Guid id)
    {
        try
        {
            return _participantWineService.GetParticipantWineById(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<ParticipantWine> CreateParticipantWine([FromBody] CreateParticipantWineDto createParticipantWineDto)
    {
        try
        {
            var createdParticipantWine = _participantWineService.CreateParticipantWine(createParticipantWineDto);
            return CreatedAtAction(nameof(GetParticipantWineById), new { id = createdParticipantWine.ParticipantWineId }, createdParticipantWine);
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
    public ActionResult DeleteParticipantWine(Guid id)
    {
        try
        {
            _participantWineService.DeleteParticipantWine(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}

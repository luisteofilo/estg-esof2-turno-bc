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
public class ParticipantController : ControllerBase
{
    private readonly ParticipantService _participantService;

    public ParticipantController()
    {
        _participantService = new ParticipantService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseParticipantDto>> GetAllParticipants()
    {
        return _participantService.GetAllParticipants();
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseParticipantDto> GetParticipantById(Guid id)
    {
        try
        {
            return _participantService.GetParticipantById(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<Participant> CreateParticipant([FromBody] CreateParticipantDto createParticipantDto)
    {
        try
        {
            var createdParticipant = _participantService.CreateParticipant(createParticipantDto);
            return CreatedAtAction(nameof(GetParticipantById), new { id = createdParticipant.ParticipantId }, createdParticipant);
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
    public ActionResult DeleteParticipant(Guid id)
    {
        try
        {
            _participantService.DeleteParticipant(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("available-users/{eventId}")]
    public ActionResult<List<ResponseUserDto>> GetAvailableUsers(Guid eventId)
    {
        try
        {
            var users = _participantService.GetAvailableUsers(eventId);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("get-by-user-and-event/{userId}/{eventId}")]
    public ActionResult<ResponseParticipantDto> GetParticipantByUserAndEvent(Guid userId, Guid eventId)
    {
        try
        {
            var participant = _participantService.GetParticipantByUserAndEvent(userId, eventId);
            if (participant == null)
            {
                return NotFound("Participant not found.");
            }
            return Ok(participant);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Controllers;

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ESOF.WebApp.WebAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class InteractionController : ControllerBase
{
    private readonly InteractionService _interactionService;

    public InteractionController()
    {
        _interactionService = new InteractionService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseInteractionDto>> GetAllInteractions()
    {
        try
        {
            return Ok(_interactionService.GetAllInteractions());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("show")]
    public ActionResult<ResponseInteractionDto> GetInteractionById([FromQuery] Guid userId, [FromQuery] Guid wineId)
    {
        try
        {
            return Ok(_interactionService.GetInteractionById(userId, wineId));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<ResponseInteractionDto> CreateInteraction([FromBody] CreateInteractionDto createInteractionDto)
    {
        try
        {
            var createdInteraction = _interactionService.CreateInteraction(createInteractionDto);
            return CreatedAtAction(nameof(GetInteractionById), new { userId = createdInteraction.UserId, wineId = createdInteraction.WineId }, createdInteraction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public ActionResult<ResponseInteractionDto> UpdateInteraction([FromQuery] Guid userId, [FromQuery] Guid wineId, [FromBody] UpdateInteractionDto updateInteractionDto)
    {
        try
        {
            return Ok(_interactionService.UpdateInteraction(userId, wineId, updateInteractionDto));
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

    [HttpDelete("delete")]
    public ActionResult DeleteInteraction([FromQuery] Guid userId, [FromQuery] Guid wineId)
    {
        try
        {
            _interactionService.DeleteInteraction(userId, wineId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
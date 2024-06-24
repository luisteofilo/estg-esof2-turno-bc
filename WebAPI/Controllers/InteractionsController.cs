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
public class InteractionsController : ControllerBase
{
    private readonly InteractionsService _interactionService;

    public InteractionsController()
    {
        _interactionService = new InteractionsService(new ApplicationDbContext());
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

    [HttpGet("show/{id}")]
    public ActionResult<ResponseInteractionDto> GetInteractionById(Guid id)
    {
        try
        {
            return Ok(_interactionService.GetInteractionById(id));
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
            return CreatedAtAction(nameof(GetInteractionById), new { id = createdInteraction.InteractionLinkId }, createdInteraction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public ActionResult<ResponseInteractionDto> UpdateInteraction(Guid id, [FromBody] UpdateInteractionDto updateInteractionDto)
    {
        try
        {
            return Ok(_interactionService.UpdateInteraction(id, updateInteractionDto));
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
    public ActionResult DeleteInteraction(Guid id)
    {
        try
        {
            _interactionService.DeleteInteraction(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}

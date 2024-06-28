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
public class TasteQuestionsController : ControllerBase
{
    private readonly TasteQuestionService _tasteQuestionService = new(new ApplicationDbContext());

    /**
     *
     * Get all taste questions.
     *
     * @return The taste questions.
     * 
     */
    [HttpGet("")]
    public ActionResult<List<ResponseTasteQuestionDto>> GetAll()
    {
        try
        {
            return Ok(_tasteQuestionService.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /**
     *
     * Get a taste question by the given id.
     *
     * @param id The id of the taste question to get.
     *
     * @return The taste question.
     * 
     */
    [HttpGet("{id}")]
    public ActionResult<ResponseTasteQuestionDto> Get(Guid id)
    {
        try
        {
            return Ok(_tasteQuestionService.Get(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    /**
     *
     * Get all taste questions by the given event id.
     *
     * @param eventId The id of the event to get the taste questions from.
     *
     * @return The taste questions.
     * 
     */
    [HttpGet("event/{eventId}")]
    public ActionResult<List<ResponseTasteQuestionDto>> GetQuestionsByEvent(Guid eventId)
    {
        try
        {
            return Ok(_tasteQuestionService.GetQuestionsByEvent(eventId));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /**
     *
     * Create a new taste question.
     *
     * @param CreateTasteQuestion The taste question to create.
     *
     * @return The created taste question.
     * 
     */
    [HttpPost("create")]
    public ActionResult<ResponseTasteQuestionDto> Create([FromBody] CreateTasteQuestionDto createTasteQuestion)
    {
        try
        {
            var created = _tasteQuestionService.Create(createTasteQuestion);
            return CreatedAtAction(nameof(Get), new { id = created.TasteQuestionId }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /**
     *
     * Update a taste question by the given id.
     *
     * @param id The id of the taste question to update.
     *
     * @param updateTasteQuestion The data to update the taste question with.
     *
     * @return The updated taste question.
     * 
     */
    [HttpPut("update/{id}")]
    public ActionResult<ResponseTasteQuestionDto> Update(Guid id, [FromBody] UpdateTasteQuestionDto updateTasteQuestion)
    {
        try
        {
            return Ok(_tasteQuestionService.Update(id, updateTasteQuestion));
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

    /**
     *
     * Delete a taste question by the given id.
     *
     * @param id The id of the taste question to delete.
     *
     * @return No content.
     * @exception NotFound If the taste question does not exist.
     * 
     */
    [HttpDelete("delete/{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            _tasteQuestionService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
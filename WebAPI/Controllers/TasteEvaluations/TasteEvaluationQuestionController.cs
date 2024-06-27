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
public class TasteEvaluationQuestionController : ControllerBase
{
    private readonly TasteEvaluationQuestionService _tasteEvaluationQuestionService = new(new ApplicationDbContext());

    /**
     *
     * Get all taste evaluation questions.
     *
     * @return The taste evaluations questions.
     * 
     */
    [HttpGet("")]
    public ActionResult<List<ResponseTasteEvaluationQuestionDto>> GetAll()
    {
        try
        {
            return Ok(_tasteEvaluationQuestionService.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /**
     *
     * Get a taste evaluation question by the given id.
     *
     * @param id The id of the taste evaluation question to get.
     *
     * @return The taste evaluation question.
     * 
     */
    [HttpGet("{id}")]
    public ActionResult<ResponseTasteEvaluationQuestionDto> Get(Guid id)
    {
        try
        {
            return Ok(_tasteEvaluationQuestionService.Get(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /**
     *
     * Create a new taste evaluation question.
     *
     * @param createTasteEvaluationQuestion The taste evaluation question to create.
     *
     * @return The created taste evaluation question.
     * 
     */
    [HttpPost("create")]
    public ActionResult<ResponseTasteEvaluationQuestionDto> Create([FromBody] CreateTasteEvaluationQuestionDto createTasteEvaluationQuestion)
    {
        try
        {
            var created = _tasteEvaluationQuestionService.Create(createTasteEvaluationQuestion);
            return CreatedAtAction(nameof(Get), new { id = created.TasteEvaluationQuestionId }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /**
     *
     * Update a taste evaluation by the given id.
     *
     * @param id The id of the taste evaluation to update.
     *
     * @param updateTasteEvaluationQuestion The data to update the taste evaluation with.
     *
     * @return The updated taste evaluation.
     * 
     */
    [HttpPut("update/{id}")]
    public ActionResult<ResponseTasteEvaluationQuestionDto> Update(Guid id, [FromBody] UpdateTasteEvaluationQuestionDto updateTasteEvaluationQuestion)
    {
        try
        {
            return Ok(_tasteEvaluationQuestionService.Update(id, updateTasteEvaluationQuestion));
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
     * Delete a taste evaluation question by the given id.
     *
     * @param id The id of the taste evaluation question to delete.
     *
     * @return No content.
     * @exception NotFound If the taste evaluation question does not exist.
     * 
     */
    [HttpDelete("delete/{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            _tasteEvaluationQuestionService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
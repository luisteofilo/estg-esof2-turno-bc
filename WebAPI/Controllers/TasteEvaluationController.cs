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
public class TasteEvaluationController : ControllerBase
{
    private readonly TasteEvaluationService _tasteEvaluationService;

    public TasteEvaluationController()
    {
        _tasteEvaluationService =  new TasteEvaluationService(new ApplicationDbContext());
    }

    /**
     *
     * Get all taste evaluations.
     *
     * @return The taste evaluations.
     * 
     */
    [HttpGet("")]
    public ActionResult<List<ResponseTasteEvaluationDto>> GetAll()
    {
        try
        {
            return Ok(_tasteEvaluationService.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /**
     *
     * Get a taste evaluation by the given id.
     *
     * @param id The id of the taste evaluation to get.
     *
     * @return The taste evaluation.
     * 
     */
    [HttpGet("{id}")]
    public ActionResult<ResponseBrandDto> Get(Guid id)
    {
        try
        {
            return Ok(_tasteEvaluationService.Get(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /**
     *
     * Create a new taste evaluation.
     *
     * @param createTasteEvaluation The taste evaluation to create.
     *
     * @return The created taste evaluation.
     * 
     */
    [HttpPost("create")]
    public ActionResult<ResponseTasteEvaluationDto> Create([FromBody] CreateTasteEvaluationDto createTasteEvaluation)
    {
        try
        {
            var created = _tasteEvaluationService.Create(createTasteEvaluation);
            return CreatedAtAction(nameof(Get), new { id = created.TasteEvaluationId }, created);
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
     * @param updateTasteEvaluation The data to update the taste evaluation with.
     *
     * @return The updated taste evaluation.
     * 
     */
    [HttpPut("update/{id}")]
    public ActionResult<ResponseTasteEvaluationDto> Update(Guid id, [FromBody] UpdateTasteEvaluationDto updateTasteEvaluation)
    {
        try
        {
            return Ok(_tasteEvaluationService.Update(id, updateTasteEvaluation));
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
     * Delete a taste evaluation by the given id.
     *
     * @param id The id of the taste evaluation to delete.
     *
     * @return No content.
     * @exception NotFound If the taste evaluation does not exist.
     * 
     */
    [HttpDelete("delete/{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            _tasteEvaluationService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
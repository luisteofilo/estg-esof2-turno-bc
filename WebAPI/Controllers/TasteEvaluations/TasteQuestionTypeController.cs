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
public class TasteQuestionsTypeController : ControllerBase
{
    private readonly TasteQuestionTypeService _tasteQuestionTypeService = new(new ApplicationDbContext());

    /**
     *
     * Get all taste questions type.
     *
     * @return The taste questions type.
     * 
     */
    [HttpGet("")]
    public ActionResult<List<ResponseTasteQuestionTypeDto>> GetAll()
    {
        try
        {
            return Ok(_tasteQuestionTypeService.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /**
     *
     * Get a taste questions type by the given id.
     *
     * @param id The id of the taste questions type to get.
     *
     * @return The taste questions type.
     * 
     */
    [HttpGet("{id}")]
    public ActionResult<ResponseTasteQuestionTypeDto> Get(Guid id)
    {
        try
        {
            return Ok(_tasteQuestionTypeService.Get(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /**
     *
     * Create a new taste questions type.
     *
     * @param createTasteQuestionType The taste questions type to create.
     *
     * @return The created taste questions type.
     * 
     */
    [HttpPost("create")]
    public ActionResult<ResponseTasteQuestionTypeDto> Create([FromBody] CreateTasteQuestionTypeDto createTasteQuestionType)
    {
        try
        {
            return Ok(_tasteQuestionTypeService.Create(createTasteQuestionType));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /**
     *
     * Update a taste questions type by the given id.
     *
     * @param id The id of the taste questions type to update.
     *
     * @param updateTasteQuestionType The data to update the taste questions type with.
     *
     * @return The updated taste questions type.
     * 
     */
    [HttpPut("update/{id}")]
    public ActionResult<ResponseTasteQuestionTypeDto> Update(Guid id, [FromBody] UpdateTasteQuestionTypeDto updateTasteQuestionType)
    {
        try
        {
            return Ok(_tasteQuestionTypeService.Update(id, updateTasteQuestionType));
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
     * Delete a taste questions type by the given id.
     *
     * @param id The id of the taste questions type to delete.
     *
     * @return No content.
     * @exception NotFound If the taste questions type does not exist.
     * 
     */
    [HttpDelete("delete/{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            _tasteQuestionTypeService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
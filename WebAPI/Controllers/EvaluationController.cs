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
public class EvaluationController : ControllerBase
{
    private readonly EvaluationService _evaluationService;

    public EvaluationController()
    {
        _evaluationService = new EvaluationService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseEvaluationDto>> GetAllEvaluations()
    {
        return _evaluationService.GetAllEvaluations();
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponseEvaluationDto> GetEvaluationById(Guid id)
    {
        try
        {
            return _evaluationService.GetEvaluationById(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<Evaluation> CreateEvaluation([FromBody] CreateEvaluationDto createEvaluationDto)
    {
        try
        {
            var createdEvaluation = _evaluationService.CreateEvaluation(createEvaluationDto);
            return CreatedAtAction(nameof(GetEvaluationById), new { id = createdEvaluation.EvaluationId }, createdEvaluation);
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
    public ActionResult DeleteEvaluation(Guid id)
    {
        try
        {
            _evaluationService.DeleteEvaluation(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
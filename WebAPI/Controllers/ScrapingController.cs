using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;

namespace ESOF.WebApp.WebAPI.Controllers;

using System;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ScrapingController : ControllerBase
{
    private readonly ScrapingService _scrapingService;

    public ScrapingController(ScrapingService scrapingService)
    {
        _scrapingService = scrapingService;
    }

    [HttpGet("wines")]
    public async Task<IActionResult> GetAllWines()
    {
        try
        {
            var wines = await _scrapingService.GetAllWines();
            return Ok(wines);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("wines")]
    public async Task<IActionResult> CreateWine([FromBody] ScrapingRequestDto scrapingRequest)
    {
        try
        {
            var wine = await _scrapingService.CreateWine(scrapingRequest);
            return Created(nameof(wine), wine);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("wines/{wineId}")]
    public async Task<IActionResult> DeleteWine(Guid wineId)
    {
        try
        {
            await _scrapingService.DeleteWine(wineId);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

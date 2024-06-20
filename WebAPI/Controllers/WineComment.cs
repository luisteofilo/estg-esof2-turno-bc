using Microsoft.AspNetCore.Mvc;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.DtoClasses;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;

namespace ESOF.WebApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WineCommentController : ControllerBase
{
    private readonly WineCommentService _wineCommentService = new(new ApplicationDbContext());

    [HttpPost("store")]
    public ActionResult<WineComment> CreateWineComment([FromBody] CreateWineCommentDto createWineCommentDto)
    {
        try
        {
            var createdWineComment = _wineCommentService.CreateWineComment(createWineCommentDto);
            return Created("api/WineComments/" + createdWineComment.WineCommentId, createdWineComment);
            //return CreatedAtAction(nameof(GetWineCommentById), new { id = createdWineComment.WineId }, createdWineComment);
            // uncomment when method GetWineCommentById is done
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
    
}
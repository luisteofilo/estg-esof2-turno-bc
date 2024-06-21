using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentsController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto dto)
    {
        var comment = await _commentService.CreateCommentAsync(dto.PostId, dto.UserId, dto.Content);
        var commentDto = new CommentDto
        {
            CommentId = comment.CommentId,
            PostId = comment.PostId,
            UserId = comment.UserId,
            Content = comment.Content,
            
        };

        return Ok(commentDto);
    }

    [HttpPost("edit")]
    public async Task<IActionResult> EditComment([FromBody] EditCommentDto dto)
    {
        try
        {
            var comment   = await _commentService.EditCommentAsync(dto.CommentId, dto.NewContent);
            var commentDto = new CommentDto
            {
                CommentId = comment.CommentId,
                PostId = comment.PostId,
                UserId = comment.UserId,
                Content = comment.Content,
                
            };

            return Ok(commentDto);
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("delete/{commentId}")]
    public async Task<IActionResult> DeleteComment(Guid commentId)
    {
        try
        {
            await _commentService.DeleteCommentAsync(commentId);
            return Ok("Comment deleted.");
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetCommentsForPost(Guid postId)
    {
        var comments = await _commentService.GetCommentsForPostAsync(postId);
        return Ok(comments);
    }
    
    [HttpGet("post/{postId}/count")]
    public async Task<IActionResult> GetCommentCountForPost(Guid postId)
    {
        var count = await _commentService.GetCommentCountForPostAsync(postId);
        return Ok(count);
    }
}
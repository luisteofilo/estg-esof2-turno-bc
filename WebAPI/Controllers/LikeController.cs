using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LikesController : ControllerBase
{
    private readonly LikeService _likeService;

    public LikesController(LikeService likeService)
    {
        _likeService = likeService;
    }

    [HttpPost("toggle")]
    public async Task<IActionResult> ToggleLike([FromBody] ToggleLikeDto dto)
    {
        var like = await _likeService.ToggleLikeAsync(dto.PostId, dto.UserId);
        return Ok(new LikeDto
        {
            LikeId = like.LikeId,
            PostId = like.PostId,
            UserId = like.UserId,
            CreatedAt = like.CreatedAt,
            IsActive = like.IsActive
        });
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetLikesForPost(Guid postId)
    {
        var likes = await _likeService.GetLikesForPostAsync(postId);
        var likeDtos = likes.Select(l => new LikeDto
        {
            LikeId = l.LikeId,
            PostId = l.PostId,
            UserId = l.UserId,
            CreatedAt = l.CreatedAt,
            IsActive = l.IsActive
        }).ToList();

        return Ok(likeDtos);
    }

    [HttpGet("post/{postId}/count")]
    public async Task<IActionResult> GetLikeCountForPost(Guid postId)
    {
        var count = await _likeService.GetLikeCountForPostAsync(postId);
        return Ok(count);
    }
    
    [HttpGet("isliked/{postId}/{userId}")]
    public async Task<IActionResult> IsLiked(Guid postId, Guid userId)
    {
        var isLiked = await _likeService.IsPostLikedByUserAsync(postId, userId);
        return Ok(isLiked);
    }
}

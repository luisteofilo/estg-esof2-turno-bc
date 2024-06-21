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
public class PostController : ControllerBase
{
    private readonly PostService _postService;

    public PostController()
    {
        _postService =  new PostService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponsePostDto>> GetAllPosts()
    {
        try
        {
            return Ok(_postService.GetAllPosts());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("show/{id}")]
    public ActionResult<ResponsePostDto> GetPostById(Guid id)
    {
        try
        {
            return Ok(_postService.GetPostById(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("store")]
    public ActionResult<ResponsePostDto> CreatePost([FromBody] CreatePostDto createPostDto)
    {
        try
        {
            var createdPost = _postService.CreatePost(createPostDto);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.PostId }, createdPost);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public ActionResult<ResponsePostDto> UpdatePost(Guid id, [FromBody] UpdatePostDto updatePostDto)
    {
        try
        {
            return Ok(_postService.UpdatePost(id, updatePostDto));
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
    public ActionResult DeletePost(Guid id)
    {
        try
        {
            _postService.DeletePost(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
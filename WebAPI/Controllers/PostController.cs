using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;

namespace ESOF.WebApp.WebAPI.Controllers
{
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
        public async Task<ActionResult<List<FeedPostDto>>> GetAllPosts()
        {
            try
            {
                return Ok(await _postService.GetAllPosts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedPostDto>> GetPostById(Guid id)
        {
            try
            {
                return Ok(await _postService.GetPostById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    

        [HttpPost("create")]
        public async Task<ActionResult<FeedPostDto>> CreatePost([FromBody] CreateFeedPostDto createPostDto)
        {
            try
            {
                var createdPost = await _postService.CreatePost(createPostDto);
                return CreatedAtAction(nameof(GetPostById), new { id = createdPost.PostId }, createdPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/update")]
        public async Task<ActionResult<FeedPostDto>> UpdatePost(Guid id, [FromBody] FeedPostDto updatePostDto)
        {
            try
            {
                return Ok(await _postService.UpdatePost(id, updatePostDto));
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

        [HttpDelete("{id}/delete")]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            try
            {
                await _postService.DeletePost(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}/media/add")]
        public ActionResult AddMediaToPost(Guid id, [FromBody] FeedPostMediaDto postMediaDto)
        {
            try
            {
                // return Ok(_postService.AddMediaToPost(id, postMediaDto));
                return Ok();
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
        
        [HttpDelete("{id}/media/remove")]
        public ActionResult RemoveMediaFromPost(Guid id, [FromBody] FeedPostMediaDto postMediaDto)
        {
            try
            {
                // return Ok(_postService.AddMediaToPost(id, postMediaDto));
                return Ok();
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

        [HttpPut("{id}/likes/add/{userId}")]
        public ActionResult AddLikeToPost(Guid id, Guid userId)
        {
            try
            {
                // return Ok(_postService.AddLikeToPost(id, userDto));
                return Ok();
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
        
        [HttpPut("{id}/likes/remove/{userId}")]
        public ActionResult RemoveLikeFromPost(Guid id, Guid userId)
        {
            try
            {
                // return Ok(_postService.RemoveLikeFromPost(id, userDto));
                return Ok();
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
}
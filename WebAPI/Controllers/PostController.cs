using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using WebAPI.DtoClasses;

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
        
        [HttpGet("index/hashtag/name/{hashtagName}")]
        public async Task<ActionResult<List<FeedPostDto>>> GetPostsByHashtagName(string hashtagName)
        {
            try
            {
                return Ok(await _postService.GetPostsByHashtagName(WebUtility.UrlDecode(hashtagName)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("index/user/username/{userName}")]
        public async Task<ActionResult<List<FeedPostDto>>> GetPostsByUserName(string userName)
        {
            try
            {
                return Ok(await _postService.GetPostsByUserName(WebUtility.UrlDecode(userName)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("index/user/email/{userEmail}")]
        public async Task<ActionResult<List<FeedPostDto>>> GetPostsByUserEmail(string userEmail)
        {
            try
            {
                return Ok(await _postService.GetPostsByUserEmail(WebUtility.UrlDecode(userEmail)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("index/user/id/{userId}")]
        public async Task<ActionResult<List<FeedPostDto>>> GetPostsByUserId(Guid userId)
        {
            try
            {
                return Ok(await _postService.GetPostsByUserId(userId));
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
        
        [HttpGet("/find/event/name/{eventName}")]
        public async Task<ActionResult<ResponseEventDto>> GetEventByName(string eventName)
        {
            try
            {
                return Ok(await _postService.GetEventByName(eventName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/find/user/id/{userId}")]
        public async Task<ActionResult<FeedPostUserDto>> GetUserById(Guid userId)
        {
            try
            {
                return Ok(await _postService.GetUserById(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [HttpGet("/find/user/email/{userEmail}")]
        public async Task<ActionResult<FeedPostUserDto>> GetUserByEmail(string userEmail)
        {
            try
            {
                return Ok(await _postService.GetUserByEmail(userEmail));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
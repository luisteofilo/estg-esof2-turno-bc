using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FriendRequestsController : ControllerBase
    {
        private readonly FriendRequestService _friendRequestService;

        public FriendRequestsController(FriendRequestService friendRequestService)
        {
            _friendRequestService = friendRequestService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendFriendRequest([FromBody] SendFriendRequestDto dto)
        {
            try
            {
                await _friendRequestService.SendFriendRequestAsync(dto.RequesterId, dto.ReceiverId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("accept")]
        public async Task<IActionResult> AcceptFriendRequest([FromBody] Guid requestId)
        {
            try
            {
                await _friendRequestService.AcceptFriendRequestAsync(requestId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectFriendRequest([FromBody] Guid requestId)
        {
            try
            {
                await _friendRequestService.RejectFriendRequestAsync(requestId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("pending/{userId}")]
        public async Task<IActionResult> GetPendingFriendRequests(Guid userId)
        {
            var friendRequests = await _friendRequestService.GetFriendRequestsForUserAsync(userId);
            return Ok(friendRequests);
        }

        [HttpGet("friendrequest-state")]
        public IActionResult GetFriendRequestState(Guid requesterId, Guid receiverId)
        {
            var state = _friendRequestService.GetFriendRequestState(requesterId, receiverId);
            if (state == null)
                return NotFound("Friend request not found.");

            return Ok(state);
        }
    }

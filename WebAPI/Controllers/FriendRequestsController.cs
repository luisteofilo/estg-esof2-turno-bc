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

        [HttpGet("pending/received/{userId}")]
        public async Task<IActionResult> GetPendingFriendRequests(Guid userId)
        {
            var friendRequests = await _friendRequestService.GetReceivedFriendRequestsForUserAsync(userId);
            var friendRequestDtos = friendRequests.Select(fr => new FriendRequestDto
            {
                RequestId = fr.RequestId,
                RequesterId = fr.RequesterId,
                RequesterName = fr.Requester.UserName,
                ReceiverId = fr.ReceiverId,
                ReceiverName = fr.Receiver.UserName,
                Status = fr.Status,
                CreatedAt = fr.CreatedAt
            }).ToList();

            return Ok(friendRequestDtos);
        }
        
        [HttpGet("pending/sent/{userId}")]
        public async Task<IActionResult> GetSentPendingFriendRequests(Guid userId)
        {
            var sentRequests = await _friendRequestService.GetSentPendingFriendRequestsAsync(userId);
            var sentRequestDtos = sentRequests.Select(fr => new FriendRequestDto
            {
                RequestId = fr.RequestId,
                RequesterId = fr.RequesterId,
                RequesterName = fr.Requester.UserName, 
                ReceiverId = fr.ReceiverId,
                ReceiverName = fr.Receiver.UserName, 
                Status = fr.Status,
                CreatedAt = fr.CreatedAt
            }).ToList();

            return Ok(sentRequestDtos);
        }
        
        [HttpDelete("remove/{requestId}")]
        public async Task<IActionResult> RemovePendingFriendRequest(Guid requestId)
        {
            try
            {
                await _friendRequestService.RemovePendingFriendRequestAsync(requestId);
                return Ok("Pending friend request removed.");
            }
            catch (FriendRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

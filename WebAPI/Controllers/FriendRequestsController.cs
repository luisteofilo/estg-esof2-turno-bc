using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
        await _friendRequestService.SendFriendRequestAsync(dto.RequesterId, dto.ReceiverId);
        return Ok();
    }

    [HttpPost("accept")]
    public async Task<IActionResult> AcceptFriendRequest([FromBody] Guid requestId)
    {
        await _friendRequestService.AcceptFriendRequestAsync(requestId);
        return Ok();
    }

    [HttpPost("reject")]
    public async Task<IActionResult> RejectFriendRequest([FromBody] Guid requestId)
    {
        await _friendRequestService.RejectFriendRequestAsync(requestId);
        return Ok();
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
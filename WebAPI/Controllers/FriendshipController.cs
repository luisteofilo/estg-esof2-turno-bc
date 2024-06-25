using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendshipController : ControllerBase
{
    private readonly FriendshipService _friendshipService;

    public FriendshipController(FriendshipService friendshipService)
    {
        _friendshipService = friendshipService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetFriends(Guid userId)
    {
        var friendships = await _friendshipService.GetFriendsForUserAsync(userId);
        var friendsDtos = friendships.Select(f => new UserDto
        {
            UserId = f.UserId,
            UserName = f.UserName,
            Email = f.Email
        }).ToList();

        return Ok(friendsDtos);
    }

    [HttpDelete("remove-friend")]
    public async Task<IActionResult> RemoveFriend(Guid userId1, Guid userId2)
    {
        try
        {
            await _friendshipService.RemoveFriendAsync(userId1, userId2);
            return Ok("Friendship removed.");
        }
        catch (FriendshipNotFoundException)
        {
            return NotFound("Friendship not found.");
        }
    }
    
    [HttpGet("ReceivedRequests/{userId}")]
    public async Task<IActionResult> GetReceivedFriendRequests(Guid userId)
    {
        var friendRequests = await _friendshipService.GetReceivedFriendRequestsAsync(userId);
        return Ok(friendRequests);
    }
    
    [HttpGet("SentRequests/{userId:guid}")]
    public async Task<IActionResult> GetSentFriendRequests(Guid userId)
    {
        var friendRequests = await _friendshipService.GetSentFriendRequestsAsync(userId);
        return Ok(friendRequests);
    }
    
    [HttpPost("accept-request/{requestId:guid}")]
    public async Task<IActionResult> AcceptFriendRequest(Guid requestId)
    { 
        Console.WriteLine("Accepting friend request with id: " + requestId);
        try
        {
            await _friendshipService.AcceptFriendRequestAsync(requestId);
            return Ok("Friend request accepted.");
        }
        catch (ApplicationException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost("send-request")]
    public async Task<IActionResult> SendFriendRequest(Guid requesterId, Guid receiverId)
    {
        try
        {
            await _friendshipService.SendFriendRequestAsync(requesterId, receiverId);
            return Ok("Friend request sent.");
        }
        catch (ApplicationException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost("cancel-request/{requestId:guid}")]
    public async Task<IActionResult> CancelFriendRequest(Guid requestId)
    {
        try
        {
            await _friendshipService.CancelFriendRequestAsync(requestId);
            return Ok("Friend request canceled.");
        }
        catch (ApplicationException e)
        {
            return NotFound(e.Message);
        }
    }
}
    
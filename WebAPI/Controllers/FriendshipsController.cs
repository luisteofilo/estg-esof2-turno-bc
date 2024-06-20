using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendshipsController : ControllerBase
{
    private readonly FriendshipService _friendshipService;

    public FriendshipsController(FriendshipService friendshipService)
    {
        _friendshipService = friendshipService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetFriends(Guid userId)
    {
        var friendships = await _friendshipService.GetFriendsForUserAsync(userId);
        return Ok(friendships);
    }

    [HttpDelete("remove-friend")]
    public IActionResult RemoveFriend(Guid userId1, Guid userId2)
    {
        var success = _friendshipService.RemoveFriend(userId1, userId2);
        if (!success)
            return NotFound("Friendship not found.");

        return Ok("Friendship removed.");
    }
}
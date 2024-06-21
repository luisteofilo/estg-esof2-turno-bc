using ESOF.WebApp.WebAPI.DtoClasses;
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
}
    
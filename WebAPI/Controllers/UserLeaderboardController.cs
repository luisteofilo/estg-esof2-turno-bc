namespace ESOF.WebApp.WebAPI.Controllers;

using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UserLeaderboardController : ControllerBase
{
    private readonly UserLeaderboardService _userLeaderboardService;

    public UserLeaderboardController(UserLeaderboardService userLeaderboardService)
    {
        _userLeaderboardService = userLeaderboardService;
    }

    [HttpGet("leaderboard")]
    public ActionResult<List<UserLeaderboardDto>> GetUserLeaderboard()
    {
        return _userLeaderboardService.GetUserLeaderboard();
    }
}
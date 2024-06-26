namespace ESOF.WebApp.WebAPI.Controllers;

using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class WineLeaderboardController : ControllerBase
{
    private readonly WineLeaderboardService _wineLeaderboardService;

    public WineLeaderboardController(WineLeaderboardService wineLeaderboardService)
    {
        _wineLeaderboardService = wineLeaderboardService;
    }

    [HttpGet("leaderboard")]
    public ActionResult<List<WineLeaderboardDto>> GetWineLeaderboard()
    {
        return _wineLeaderboardService.GetWineLeaderboard();
    }
}
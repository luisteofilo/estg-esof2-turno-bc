namespace Frontend.Services;

using DtoClasses;
using Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserLeaderboardService
{
    private readonly ApiHelper _apiHelper;

    public UserLeaderboardService(ApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    public async Task<List<UserLeaderboardDto>> GetUserLeaderboardAsync()
    {
        var result = await _apiHelper.GetFromApiAsync<List<UserLeaderboardDto>>("api/userleaderboard/leaderboard");
        return result ?? new List<UserLeaderboardDto>();
    }
}
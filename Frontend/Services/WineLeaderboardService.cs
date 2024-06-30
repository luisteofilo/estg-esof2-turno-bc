namespace Frontend.Services;

using DtoClasses;
using Helpers;

public class WineLeaderboardService
{
    private readonly ApiHelper _apiHelper;

    public WineLeaderboardService(ApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    public async Task<List<WineLeaderboardDto>> GetWineLeaderboardAsync()
    {
        var result = await _apiHelper.GetFromApiAsync<List<WineLeaderboardDto>>("api/wineleaderboard/leaderboard");
        return result ?? new List<WineLeaderboardDto>();
    }

    public async Task<List<WineLeaderboardDto>> GetWineLeaderboardByRegionAsync(Guid? regionId)
    {
        if (regionId == null)
        {
            return await GetWineLeaderboardAsync();
        }
        var result = await _apiHelper.GetFromApiAsync<List<WineLeaderboardDto>>($"api/wineleaderboard/leaderboard/byregion/{regionId}");
        return result ?? new List<WineLeaderboardDto>();
    }
}
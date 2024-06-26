using Frontend.DtoClasses;
using Frontend.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Frontend.Services
{
    public class WineLeaderboardService
    {
        private readonly ApiHelper _apiHelper;

        public WineLeaderboardService(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<WineLeaderboardDto>> GetLeaderboardAsync()
        {
            var result = await _apiHelper.GetFromApiAsync<List<WineLeaderboardDto>>("api/wineleaderboard/leaderboard");
            return result ?? new List<WineLeaderboardDto>();
        }

        public async Task<List<WineLeaderboardDto>> GetLeaderboardByRegionAsync(Guid? regionId)
        {
            if (regionId == null)
            {
                return await GetLeaderboardAsync();
            }
            var result = await _apiHelper.GetFromApiAsync<List<WineLeaderboardDto>>($"api/wineleaderboard/leaderboard/byregion/{regionId}");
            return result ?? new List<WineLeaderboardDto>();
        }
    }
}
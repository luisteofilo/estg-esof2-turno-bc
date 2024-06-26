namespace Frontend.Services;

using Frontend.DtoClasses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class WineLeaderboardService
{
    private readonly HttpClient _httpClient;

    public WineLeaderboardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WineLeaderboardDto>> GetLeaderboardAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<WineLeaderboardDto>>("api/wineleaderboard/leaderboard");
        return result ?? new List<WineLeaderboardDto>();
    }
}
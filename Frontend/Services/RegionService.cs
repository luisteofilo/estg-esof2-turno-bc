namespace Frontend.Services;

using DtoClasses;
using Helpers;

public class RegionService
{
    private readonly ApiHelper _apiHelper;

    public RegionService(ApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    public async Task<List<RegionDto>> GetRegionsAsync()
    {
        var result = await _apiHelper.GetFromApiAsync<List<RegionDto>>("api/region/index");
        return result ?? new List<RegionDto>();
    }
}
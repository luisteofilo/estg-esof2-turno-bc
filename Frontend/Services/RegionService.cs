using Frontend.DtoClasses;
using Frontend.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend.Services
{
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
}
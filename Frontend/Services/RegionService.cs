using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ESOF.WebApp.DBLayer.Entities;
using Frontend.DtoClasses;

namespace Frontend.Services
{
    public class RegionService
    {
        private readonly HttpClient _httpClient;

        public RegionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<RegionDto>?> GetAllRegions()
        {
            return await _httpClient.GetFromJsonAsync<List<RegionDto>>("api/region/index");
        }
    }
}
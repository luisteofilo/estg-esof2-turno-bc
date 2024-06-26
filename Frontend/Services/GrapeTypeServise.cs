using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ESOF.WebApp.DBLayer.Entities;
using Frontend.DtoClasses;

namespace Frontend.Services
{
    public class GrapeTypeService
    {
        private readonly HttpClient _httpClient;

        public GrapeTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<GrapeType>?> GetAllGrapeTypes()
        {
            return await _httpClient.GetFromJsonAsync<List<GrapeType>>("api/ GrapeTypeController/index");
        }
    }
}
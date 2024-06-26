using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ESOF.WebApp.DBLayer.Entities;
using Frontend.DtoClasses;

namespace Frontend.Services
{
    public class BrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<BrandDto>?> GetAllBrands()
        {
            return await _httpClient.GetFromJsonAsync<List<BrandDto>>("api/brand/index");
        }
    }
}
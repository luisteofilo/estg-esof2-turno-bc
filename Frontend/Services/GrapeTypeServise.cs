﻿using System;
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
        public async Task<List<GrapeTypeDto>?> GetAllGrapeTypes()
        {
            return await _httpClient.GetFromJsonAsync<List<GrapeTypeDto>>("api/grape/index");
        }
    }
}
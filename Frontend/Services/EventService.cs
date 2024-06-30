using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend.DtoClasses;
using System;

namespace Frontend.Services
{
    public class EventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EventDto>> GetEvents()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<EventDto>>("api/events");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return new List<EventDto>();
            }
        }

        public async Task<EventDto> GetEventBySlug(string slug)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/events/{slug}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<EventDto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return null;
            }
        }
    }
}
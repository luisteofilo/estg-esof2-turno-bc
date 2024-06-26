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
        public async Task<List<EventDto>> GetEventsSelection(
            string filtroNome,
            string filtroNomeUser,
            string filtroNomeVinho,
            string filtroRegion,
            string filtroBrand,
            Guid? filtroTipoUva)
        {
            try
            {
                // Construir a URL com parâmetros de consulta
                var queryParams = new List<string>();
                if (!string.IsNullOrEmpty(filtroNome)) queryParams.Add($"filtroNome={Uri.EscapeDataString(filtroNome)}");
                if (!string.IsNullOrEmpty(filtroNomeUser)) queryParams.Add($"filtroNomeUser={Uri.EscapeDataString(filtroNomeUser)}");
                if (!string.IsNullOrEmpty(filtroNomeVinho)) queryParams.Add($"filtroNomeVinho={Uri.EscapeDataString(filtroNomeVinho)}");
                if (!string.IsNullOrEmpty(filtroRegion)) queryParams.Add($"filtroRegion={Uri.EscapeDataString(filtroRegion)}");
                if (!string.IsNullOrEmpty(filtroBrand)) queryParams.Add($"filtroBrand={Uri.EscapeDataString(filtroBrand)}");
                if (filtroTipoUva.HasValue) queryParams.Add($"filtroTipoUva={Uri.EscapeDataString(filtroTipoUva.Value.ToString())}");

                string queryString = string.Join("&", queryParams);
                string requestUrl = $"api/events/select?{queryString}";

                // Fazer a chamada HTTP para a API
                return await _httpClient.GetFromJsonAsync<List<EventDto>>(requestUrl);
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
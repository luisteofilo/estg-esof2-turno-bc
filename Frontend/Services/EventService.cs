﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend.DtoClasses;
using System;
using Microsoft.Extensions.Logging;

namespace Frontend.Services
{
    public class EventService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EventService> _logger;

        public EventService(HttpClient httpClient, ILogger<EventService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<EventDto>> GetEvents()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<EventDto>>("api/events");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Request error: {ex.Message}");
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
                _logger.LogError($"Request error: {ex.Message}");
                return null;
            }
        }

        public async Task AddEvent(CreateEventDto newEvent)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/events", newEvent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Request error: {ex.Message}");
            }
        }

        public async Task DeleteEvent(string slug)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/events/slug/{slug}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Request error: {ex.Message}");
            }
        }
        
        public async Task<List<EventParticipantDto>> GetParticipants(Guid eventId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<EventParticipantDto>>($"api/events/{eventId}/participants");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Request error: {ex.Message}");
                return new List<EventParticipantDto>();
            }
        }

        public async Task AddParticipant(Guid eventId, Guid userId)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/events/{eventId}/participants", new { userId });
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Request error: {ex.Message}");
            }
        }

        public async Task RemoveParticipant(Guid eventId, Guid participantId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/events/{eventId}/participants/{participantId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Request error: {ex.Message}");
            }
        }
    }
}
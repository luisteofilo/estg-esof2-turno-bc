using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Threading;
using Frontend.DtoClasses;

namespace Frontend.Services
{
    public class RolesService
    {
        private readonly HttpClient _http;

        public RolesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RolesDto>?> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<RolesDto>>("api/Role", cancellationToken);
            }
            catch (HttpRequestException ex) when (ex.InnerException is IOException)
            {
                Console.WriteLine($"An IO error has occurred: {ex.Message} | {ex.InnerException?.Message}");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"The operation was canceled: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return null;
        }
        
        public Boolean Create(RolesDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PostAsJsonAsync("api/Role/create", data, cancellationToken).Wait(cancellationToken);
                return true;
            }
            catch (HttpRequestException ex) when (ex.InnerException is IOException)
            {
                Console.WriteLine($"An IO error has occurred: {ex.Message} | {ex.InnerException?.Message}");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"The operation was canceled: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return false;
        }

        public async Task<bool> Update(Guid id, RolesDto roleDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Role/update/{id}", roleDto, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex) when (ex.InnerException is IOException)
            {
                Console.WriteLine($"An IO error has occurred: {ex.Message} | {ex.InnerException?.Message}");
            }

            return false;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/Role/delete/{id}", cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex) when (ex.InnerException is IOException)
            {
                Console.WriteLine($"An IO error has occurred: {ex.Message} | {ex.InnerException?.Message}");
            }

            return false;
        }
        
        public async Task<RolesDto> GetRoleById(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<RolesDto>($"api/Role/{id}", cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while fetching the role.", e);
            }
        }
    }
}

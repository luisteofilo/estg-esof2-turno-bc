using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Threading;
using Frontend.DtoClasses;

namespace Frontend.Services
{
    public class PermissionService
    {
        private readonly HttpClient _http;

        public PermissionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PermissionsDto>?> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<PermissionsDto>>("api/Permission", cancellationToken);
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
        
        public async Task<bool> Create(PermissionsDto permissionDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Permission/create", permissionDto, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error creating permission: {error}");
                    return false;
                }
            }
            catch (HttpRequestException ex) when (ex.InnerException is IOException)
            {
                Console.WriteLine($"An IO error has occurred: {ex.Message} | {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return false;
        }

        public async Task<bool> Update(Guid id, PermissionsDto permissionDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Permission/update/{id}", permissionDto, cancellationToken);
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
                var response = await _http.DeleteAsync($"api/Permission/delete/{id}", cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex) when (ex.InnerException is IOException)
            {
                Console.WriteLine($"An IO error has occurred: {ex.Message} | {ex.InnerException?.Message}");
            }

            return false;
        }
        
        public async Task<PermissionsDto> GetPermissionById(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<PermissionsDto>($"api/Permission/{id}", cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while fetching the permission.", e);
            }
        }
    }
}

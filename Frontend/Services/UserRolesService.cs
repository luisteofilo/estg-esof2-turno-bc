using Frontend.DtoClasses;

namespace Frontend.Services;

public class UserRolesService
{
            private readonly HttpClient _http;
    
            public UserRolesService(HttpClient http)
            {
                _http = http;
            }
    
            public async Task<List<UserRolesDto>?> Get(CancellationToken cancellationToken = default)
            {
                try
                {
                    return await _http.GetFromJsonAsync<List<UserRolesDto>>("api/UserRole", cancellationToken);
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
        
}
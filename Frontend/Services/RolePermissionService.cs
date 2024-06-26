using Frontend.DtoClasses;

namespace Frontend.Services;

public class RolePermissionService
{
    private readonly HttpClient _http;
    
    public RolePermissionService(HttpClient http)
    {
        _http = http;
    }
    
    public async Task<List<RolePermissionsDto>?> Get(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _http.GetFromJsonAsync<List<RolePermissionsDto>>("api/RolePermission", cancellationToken);
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
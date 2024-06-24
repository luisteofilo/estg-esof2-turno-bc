namespace Frontend.Helpers;

public class ApiHelper
{
    private readonly HttpClient _httpClient;

    public ApiHelper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetFromApiAsync<T>(string url)
    {
        try
        {
            Console.WriteLine($"Requesting URL: {_httpClient.BaseAddress}{url}"); // Adicione esta linha para depuração
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"Error fetching data from {url}: {e.Message}");
        }
    }
}
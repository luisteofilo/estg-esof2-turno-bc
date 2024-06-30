using Frontend.DtoClasses;

namespace Frontend.Services;

public class ScrapingService
{
    private readonly HttpClient _http;

    public ScrapingService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ScrapedWineDto>?> GetAllWines()
    {
        var url = "api/Scraping/wines";
        try
        {
            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ScrapedWineDto>>();
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"Error fetching {url}: {e.Message}");
        }
    }

    public async Task<ScrapedWineDto?> CreateWineScrapingRequest(ScrapingRequestDto scrapingRequest)
    {
        var url = "api/Scraping/wines";
        try
        {
            var response = await _http.PostAsJsonAsync(url, scrapingRequest);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ScrapedWineDto>();
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"Error posting {url}: {e.Message}");
        }
    }

    public async Task DeleteWine(Guid wineId)
    {
        var url = $"api/Scraping/wines/{wineId}";
        try
        {
            var response = await _http.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"Error deleting {url}: {e.Message}");
        }
    }
}

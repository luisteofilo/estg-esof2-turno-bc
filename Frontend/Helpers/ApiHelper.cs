namespace Frontend.Helpers
{
    public class ApiHelper
    {
        private readonly HttpClient _httpClient;

        public ApiHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResponse?> PostToApiAsync<TRequest, TResponse>(string url, TRequest data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                Console.Error.WriteLine($"Error posting data to {url}: {e.Message}");
                throw new ApplicationException($"Error posting data to {url}: {e.Message}");
            }
        }

        public async Task<T?> GetFromApiAsync<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                Console.Error.WriteLine($"Error fetching data from {url}: {e.Message}");
                throw new ApplicationException($"Error fetching data from {url}: {e.Message}");
            }
        }

        public async Task DeleteFromApiAsync(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                Console.Error.WriteLine($"Error deleting data from {url}: {e.Message}");
                throw new ApplicationException($"Error deleting data from {url}: {e.Message}");
            }
        }
    }
}

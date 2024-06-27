namespace Frontend.Helpers
{
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
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException($"Error fetching data from {url}: {e.Message}");
            }
        }

        public async Task<HttpResponseMessage> PostToApiAsync3(string url, HttpContent content)
        {
            try
            {
                Console.WriteLine($"Content-Type being sent: {content.Headers.ContentType}");
                
                var response = await _httpClient.PostAsync(url, content);
                return response;
            }
            catch (HttpRequestException e)
            {
                string errorMessage = string.Empty;
                if (e.InnerException != null)
                {
                    errorMessage = e.InnerException.Message;
                }
                throw new ApplicationException($"Error posting data to {url}: {e.Message}. Inner Exception: {errorMessage}");
            }
        }
    }
}
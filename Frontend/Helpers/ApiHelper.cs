using ESOF.WebApp.WebAPI.DtoClasses;

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
                // Handle exception
                Console.Error.WriteLine($"Error fetching data from {url}: {e.Message}");
                throw new ApplicationException($"Error fetching data from {url}: {e.Message}");
            }
        }

        
        public async Task<R?> PostToApiAsync<T, R>(string url, T data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<R>();
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                throw new ApplicationException($"Error posting data to {url}: {e.Message}");
            }
        }
        
        public async Task PostToApiAsync2<T>(string url, T data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                throw new ApplicationException($"Error posting data to {url}: {e.Message}");
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
        
        public async Task DeleteFromApiAsync2(string url, Guid requestId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{url}/{requestId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                throw new ApplicationException($"Error deleting data from {url}: {e.Message}");
            }
        }
        
        public async Task DeleteFromApiAsync3(string url, RemoveFriendDto removeFriendDto)
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

        public async Task<R?> PutToApiAsync<T, R>(string url, T data)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<R>();
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                throw new ApplicationException($"Error putting data to {url}: {e.Message}");
            }
        }
        
        public class ApiResponse<T>
        {
            public bool IsSuccess { get; }
            public T Content { get; }

            public ApiResponse(bool isSuccess, T content)
            {
                IsSuccess = isSuccess;
                Content = content;
            }
        }
    }
    
    public async Task<T?> PostToApiAsync<T>(string url, T data)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        catch (HttpRequestException e)
        {
            // Handle exception
            throw new ApplicationException($"Error posting data to {url}: {e.Message}");
        }
    }

    public async Task<T?> PutToApiAsync<T>(string url, T data)
    {
        try
        {
            var response = await httpClient.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        catch (HttpRequestException e)
        {
            // Handle exception
            throw new ApplicationException($"Error putting data to {url}: {e.Message}");
        }
    }
}
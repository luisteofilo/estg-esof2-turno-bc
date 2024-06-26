using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            return await _httpClient.GetFromJsonAsync<UserProfileDto>("api/user/profile");
        }
    }

    public class UserProfileDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public WineDto FavoriteWine { get; set; }
    }

    public class WineDto
    {
        public Guid WineId { get; set; }
        public string Name { get; set; }
        public BrandDto Brand { get; set; }
        public RegionDto Region { get; set; }
    }

    public class BrandDto
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }
    }

    public class RegionDto
    {
        public Guid RegionId { get; set; }
        public string Name { get; set; }
    }
}
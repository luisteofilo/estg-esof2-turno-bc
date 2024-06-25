using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend.DtoClasses;
using System;

namespace Frontend.Services
{
    public class TasteQuestionService(HttpClient _http)
    {
        public async Task<List<TasteQuestionDto>?> Get()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<TasteQuestionDto>>("api/TasteQuestions");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error has occured: {ex.Message} | {ex.InnerException}");
                return new List<TasteQuestionDto>();
            }
        }
    }
}
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend.DtoClasses;
using System;
using System.Threading;

namespace Frontend.Services
{
    public class TasteQuestionTypeService
    {
        private readonly HttpClient _http;

        public TasteQuestionTypeService(HttpClient http)
        {
            _http = http;
        }
        
        public async Task<List<TasteQuestionTypeDto>?> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<TasteQuestionTypeDto>>("api/TasteQuestionsType", cancellationToken);
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
        
        public string GetType(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _http.GetFromJsonAsync<TasteQuestionTypeDto>($"api/TasteQuestionsType/{id}", cancellationToken).Result;
                return result.Type;
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

            return "";
        }
        
        public Boolean Create(TasteQuestionDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PostAsJsonAsync("api/TasteQuestions/create", data, cancellationToken).Wait(cancellationToken);
                return true;
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

            return false;
        }
        
        public Boolean Update(Guid id, TasteQuestionDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PutAsJsonAsync($"api/TasteQuestions/update/{id}", data, cancellationToken).Wait(cancellationToken);
                return true;
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

            return false;
        }
        
        public Boolean Delete(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.DeleteAsync($"api/TasteQuestions/delete/{id}", cancellationToken).Wait(cancellationToken);
                return true;
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
        
            return false;
        }
    }
}
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
        
        /**
         *
         * Get all TasteQuestionTypeDto objects from the backend
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return List of TasteQuestionTypeDto objects
         *
         * @exception HttpRequestException An error occurred while sending the request
         * 
         */
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
        
        /**
         *
         * Get a TasteQuestionTypeDto object by its id
         *
         * @param id Id of the TasteQuestionTypeDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         */
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
        
        /**
         *
         * Create a new TasteQuestionTypeDto object
         *
         * @param data TasteQuestionTypeDto object to create
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean indicating success
         * 
         */
        public Boolean Create(TasteQuestionTypeDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PostAsJsonAsync("api/TasteQuestionsType/create", data, cancellationToken).Wait(cancellationToken);
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
        
        /**
         *
         * Update a TasteQuestionTypeDto object
         *
         * @param id Id of the TasteQuestionTypeDto object
         *
         * @param data TasteQuestionTypeDto object to update
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean indicating success
         * 
         */
        public Boolean Update(Guid id, TasteQuestionTypeDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PutAsJsonAsync($"api/TasteQuestionsType/update/{id}", data, cancellationToken).Wait(cancellationToken);
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
        
        /**
         *
         * Delete a TasteQuestionTypeDto object by its id
         *
         * @param id Id of the TasteQuestionTypeDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean indicating success
         * 
         */
        public Boolean Delete(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.DeleteAsync($"api/TasteQuestionsType/delete/{id}", cancellationToken).Wait(cancellationToken);
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
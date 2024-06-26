using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend.DtoClasses;
using System;
using System.Threading;

namespace Frontend.Services
{
    public class TasteQuestionService
    {
        private readonly HttpClient _http;

        public TasteQuestionService(HttpClient http)
        {
            _http = http;
        }

        /**
         *
         * Get all TasteQuestionDto objects from the backend
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return List of TasteQuestionDto objects
         *
         * @exception HttpRequestException An error occurred while sending the request
         * 
         */
        public async Task<List<TasteQuestionDto>?> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<TasteQuestionDto>>("api/TasteQuestions", cancellationToken);
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
         * Get a TasteQuestionDto object by its id
         *
         * @param id Id of the TasteQuestionDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return TasteQuestionDto object
         * 
         */
        public Task<List<TasteQuestionDto>?> GetQuestionsByEvent(Guid EventId, CancellationToken cancellationToken = default)
        {
            try
            {
                return _http.GetFromJsonAsync<List<TasteQuestionDto>>($"api/TasteQuestions/event/{EventId}", cancellationToken);
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
         * Create a new TasteQuestionDto object
         *
         * @param data TasteQuestionDto object to create
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean indicating success
         * 
         */
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
        
        /**
         *
         * Update a TasteQuestionDto object
         *
         * @param id Id of the TasteQuestionDto object
         *
         * @param data TasteQuestionDto object to update
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean indicating success
         * 
         */
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
        
        /**
         *
         * Delete a TasteQuestionDto object by its id
         *
         * @param id Id of the TasteQuestionDto object
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
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend.DtoClasses;
using System;
using System.Threading;

namespace Frontend.Services
{
    public class TasteEvaluationQuestionService
    {
        private readonly HttpClient _http;

        public TasteEvaluationQuestionService(HttpClient http)
        {
            _http = http;
        }

        /**
         * 
         * Get all TasteEvaluationQuestionDto objects from the backend
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return List of TasteEvaluationQuestionDto objects
         *
        * @exception HttpRequestException An error occurred while sending the request
         * 
         */
        public async Task<List<TasteEvaluationQuestionDto>?> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<TasteEvaluationQuestionDto>>("api/TasteEvaluationQuestionDto", cancellationToken);
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
         * Get a TasteEvaluationQuestionDto object by its id
         *
         * @param id Id of the TasteEvaluationQuestionDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return TasteEvaluationQuestionDto object
         * 
         */
        public Boolean Create(TasteEvaluationQuestionDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PostAsJsonAsync("api/TasteEvaluationQuestion/create", data, cancellationToken).Wait(cancellationToken);
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
         * Update a TasteEvaluationQuestionDto object by its id
         *
         * @param id Id of the TasteEvaluationQuestionDto object
         *
         * @param data TasteEvaluationQuestionDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean value indicating if the update was successful
         * 
         */
        public Boolean Update(Guid id, TasteEvaluationQuestionDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PutAsJsonAsync($"api/TasteEvaluationQuestion/update/{id}", data, cancellationToken).Wait(cancellationToken);
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
         * Delete a TasteEvaluationQuestionDto object by its id
         *
         * @param id Id of the TasteEvaluationQuestionDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean value indicating if the deletion was successful
         * 
         */
        public Boolean Delete(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.DeleteAsync($"api/TasteEvaluationQuestion/delete/{id}", cancellationToken).Wait(cancellationToken);
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
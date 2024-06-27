using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend.DtoClasses;
using System;
using System.Threading;

namespace Frontend.Services
{
    public class TasteEvaluationService
    {
        private readonly HttpClient _http;

        public TasteEvaluationService(HttpClient http)
        {
            _http = http;
        }

        /**
         *
         * Get all TasteEvaluationDto objects from the backend
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return List of TasteEvaluationDto objects
         *
         * @exception HttpRequestException An error occurred while sending the request
         * 
         */
        public async Task<List<TasteEvaluationDto>?> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<TasteEvaluationDto>>("api/TasteEvaluation", cancellationToken);
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
         * Get a TasteEvaluationDto object by its id
         *
         * @param id Id of the TasteEvaluationDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return TasteEvaluationDto object
         * 
         */
        public Boolean Create(TasteEvaluationDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PostAsJsonAsync("api/TasteEvaluation/create", data, cancellationToken).Wait(cancellationToken);
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
         * Update a TasteEvaluationDto object
         *
         * @param id Id of the TasteEvaluationDto object
         *
         * @param data New data for the TasteEvaluationDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean indicating if the update was successful
         * 
         */
        public Boolean Update(Guid id, TasteEvaluationDto data, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.PutAsJsonAsync($"api/TasteEvaluation/update/{id}", data, cancellationToken).Wait(cancellationToken);
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
         * Delete a TasteEvaluationDto object by its id
         *
         * @param id Id of the TasteEvaluationDto object
         *
         * @param cancellationToken Token to cancel the request
         *
         * @return Boolean indicating if the delete was successful
         * 
         */
        public Boolean Delete(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                _http.DeleteAsync($"api/TasteEvaluation/delete/{id}", cancellationToken).Wait(cancellationToken);
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
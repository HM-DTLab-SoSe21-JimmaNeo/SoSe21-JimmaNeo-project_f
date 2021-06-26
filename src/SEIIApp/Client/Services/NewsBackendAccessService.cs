using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using SEIIApp.Shared;

namespace SEIIApp.Client.Services
{
    public class NewsBackendAccessService
    {
        private HttpClient HttpClient { get; set; }

        public NewsBackendAccessService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        private string GetNewsUrl()
        {
            return "api/news";
        }

        /// <summary>
        /// Returns all news stored on the backend. 
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsDTO>> GetNews()
        {
            return await HttpClient.GetFromJsonAsync<List<NewsDTO>>(GetNewsUrl());
        }

        /// <summary>
        /// Adds or updates a news on the backend. Returns the news if successful else null.
        /// </summary>
        /// <param name="newsDTO"></param>
        /// <returns></returns>
        public async Task<NewsDTO> AddOrUpdateNews(NewsDTO newsDTO)
        {
            var response = await HttpClient.PutAsJsonAsync(GetNewsUrl(), newsDTO);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<NewsDTO>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a news and returns true if successful.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteNews(int id)
        {
            var response = await HttpClient.DeleteAsync(GetNewsUrl() + $"/{id}");
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}

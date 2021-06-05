using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

        public async Task<List<NewsDTO>> GetNews()
        {
            return await HttpClient.GetFromJsonAsync<List<NewsDTO>>(GetNewsUrl());
        }

        public async Task<NewsDTO> AddOrUpdateNews(NewsDTO newsDTO)
        {
            var response = await HttpClient.PutAsJsonAsync(GetNewsUrl(), newsDTO);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<NewsDTO>();
            }
            else return null;
        }

        public async Task<bool> DeleteNews(int id)
        {
            var response = await HttpClient.DeleteAsync(GetNewsUrl() + $"/{id}");
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}

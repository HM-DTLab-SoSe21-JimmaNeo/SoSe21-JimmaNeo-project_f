using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEIIApp.Shared;

namespace SEIIApp.Client.Services
{
    
    public class CompletedTestBackendAccessService
    {

        private HttpClient HttpClient { get; set; }

        public CompletedTestBackendAccessService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }
        
        private string GetCompletedTestUrl()
        {
            return "api/completedtest";
        }

        public async Task<CompletedTestDTO> GetCompletedTestWithId(int id)
        {
            return await HttpClient.GetFromJsonAsync<CompletedTestDTO>(GetCompletedTestUrl() + $"/{id}");
        }

        public async Task<CompletedTestDTO[]> GetCompletedTestsWithUserId(int userId)
        {
            return await HttpClient.GetFromJsonAsync<CompletedTestDTO[]>(GetCompletedTestUrl() + $"/userId/{userId}");
        }
        
        public async Task<CompletedTestDTO[]> GetCompletedTestsWithTestId(int testId)
        {
            return await HttpClient.GetFromJsonAsync<CompletedTestDTO[]>(GetCompletedTestUrl() + $"/testId/{testId}");
        } 

        public async Task<CompletedTestDTO> AddCompletedTest(CompletedTestDTO completedTestDTO)
        {
            var response = await HttpClient.PutAsJsonAsync(GetCompletedTestUrl(), completedTestDTO);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<CompletedTestDTO>();
            }
            else return null;
        }


    }
}

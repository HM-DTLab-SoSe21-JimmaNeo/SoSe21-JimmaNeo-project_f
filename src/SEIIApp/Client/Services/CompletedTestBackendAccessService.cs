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
            try
            {
                return await HttpClient.GetFromJsonAsync<CompletedTestDTO>(GetCompletedTestUrl() + $"/{id}");
            } catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<CompletedTestDTO[]> GetCompletedTestsWithUserId(int userId)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<CompletedTestDTO[]>(GetCompletedTestUrl() + $"/userId/{userId}");
            }
            catch (HttpRequestException) { 
                return null; 
            }
         }
        
        public async Task<CompletedTestDTO[]> GetCompletedTestsWithTestId(int testId)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<CompletedTestDTO[]>(GetCompletedTestUrl() + $"/testId/{testId}");
            } catch (HttpRequestException)
            {
                return null;
            }   
        }

        public async Task<CompletedTestDTO[]> GetCompletedTestsWithAuthotId(int authorId)
        {
            try {
                return await HttpClient.GetFromJsonAsync<CompletedTestDTO[]>(GetCompletedTestUrl() + $"/authorId/{authorId}");
            } catch (HttpRequestException)
            {
                return null;
            }
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

using System.Net.Http;
using System.Net.Http.Json;
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

        /// <summary>
        /// Returns a completed test with the id, if its exists else null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all completed tests which were solved by the user with the given id.
        /// If there are no tests which were solved by the user it returns null.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Returns all completed tests for a concrete test by its id. 
        /// If this test wasn´t solved yet it returns null. 
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all completed tests which were created by the user with the given id.
        /// If the user hasn`t created a test yet it returns null.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public async Task<CompletedTestDTO[]> GetCompletedTestsWithAuthotId(int authorId)
        {
            try {
                return await HttpClient.GetFromJsonAsync<CompletedTestDTO[]>(GetCompletedTestUrl() + $"/authorId/{authorId}");
            } catch (HttpRequestException)
            {
                return null;
            }
        }

        /// <summary>
        /// Adds a completed test. Returns the test if successful else null.
        /// </summary>
        /// <param name="completedTestDTO"></param>
        /// <returns></returns>
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

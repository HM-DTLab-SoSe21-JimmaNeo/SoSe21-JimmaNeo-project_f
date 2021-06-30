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

  public class TestsDefinitionBackendAccessService
  {

    private HttpClient HttpClient { get; set; }

    public TestsDefinitionBackendAccessService(HttpClient client)
    {
      this.HttpClient = client;
    }

    private string GetTestDefinitionUrl()
    {
      return "api/tests";
    }

    private string GetTestDefinitionUrlWithId(int TestID)
    {
      return $"{GetTestDefinitionUrl()}/{TestID}";
    }

    /// <summary>
    /// Returns a certain test by id
    /// </summary>
    public async Task<TestDTO> GetTestById(int TestID)
    {
      return await HttpClient.GetFromJsonAsync<TestDTO>(GetTestDefinitionUrlWithId(TestID));
    }



    /// <summary>
    /// Returns all tests stored on the backend
    /// </summary>
    public async Task<List<TestDTO>> GetTestOverview()
    {
      return await HttpClient.GetFromJsonAsync<List<TestDTO>>(GetTestDefinitionUrl());
    }

    /// <summary>
    /// Adds or updates a tests on the backend. Returns the tests if successful else null
    /// </summary>
    public async Task<TestDTO> AddOrUpdateTest(TestDTO dto)
    {
      var response = await HttpClient.PutAsJsonAsync(GetTestDefinitionUrl(), dto);
      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        return await response.DeserializeResponseContent<TestDTO>();
      }
      return null;
    }

    /// <summary>
    /// Deletes a tests and returns true if successful
    /// </summary>
    public async Task<bool> DeleteTest(int TestID)
    {
      var response = await HttpClient.DeleteAsync(GetTestDefinitionUrlWithId(TestID));
      return response.StatusCode == System.Net.HttpStatusCode.OK;
    }

  }
}

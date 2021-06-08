using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEIIApp.Shared;
using SEIIApp.Client.Services;


namespace SEIIApp.Client.Services
{

    public class LectureBackendAccessService
    {

        private HttpClient HttpClient { get; set; }

        public LectureBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        private string GetLectureUrl()
        {
            return "api/lectures";
        }

        private string GetLectureUrlWithId(int LectureID)
        {
            return $"{GetLectureUrl()+"/SearchLectureID"}/{LectureID}";
        }

        /// <summary>
        /// Returns a certain lecture by id
        /// </summary>
        public async Task<LectureDTO> GetLectureById(int LectureID)
        {
            return await HttpClient.GetFromJsonAsync<LectureDTO>(GetLectureUrlWithId(LectureID));
        }

        public async Task<TestBaseDTO> GetTestById(int TestID)
        {
            return await HttpClient.GetFromJsonAsync<TestBaseDTO>($"api/tests/{TestID}");
        }
        /// <summary>
        /// Returns all lectures stored on the backend
        /// </summary>
        public async Task<List<LectureDTO>> GetLectureOverview()
        {
            return await HttpClient.GetFromJsonAsync<List<LectureDTO>>(GetLectureUrl()+"/ShowLectures");
        }

        /// <summary>
        /// Adds or updates a lectures on the backend. Returns the lectures if successful else null
        /// </summary>
        public async Task<LectureDTO> AddOrUpdateLecture(LectureDTO dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetLectureUrl()+"/ChangeLecture", dto);
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<LectureDTO>();
            }
            return null;
        }

        /// <summary>
        /// Deletes a lectures and returns true if successful
        /// </summary>
        public async Task<bool> DeleteLecture(int LectureID)
        {
            var response = await HttpClient.DeleteAsync(GetLectureUrlWithId(LectureID));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}

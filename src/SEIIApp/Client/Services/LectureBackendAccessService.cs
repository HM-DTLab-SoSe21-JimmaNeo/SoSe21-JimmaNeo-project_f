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

        /// <summary>
        /// Returns url of certian lecture by id
        /// </summary>
        /// <param name="lectureID"></param>
        private string GetLectureUrlWithId(int lectureID)
        {
            return $"{GetLectureUrl()+"/SearchLectureID"}/{lectureID}";
        }

        /// <summary>
        /// Returns a certain lecture by id
        /// </summary>
        /// <param name="lectureID"></param>
        public async Task<LectureDTO> GetLectureById(int lectureID)
        {
            return await HttpClient.GetFromJsonAsync<LectureDTO>(GetLectureUrlWithId(lectureID));
        }

        /// <summary>
        /// Returns certain Test by id
        /// </summary>
        /// <param name="testID"></param>
        public async Task<TestBaseDTO> GetTestById(int testID)
        {
            return await HttpClient.GetFromJsonAsync<TestBaseDTO>($"api/tests/{testID}");
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
        /// <param name="dto"></param>
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
        /// <param name="lectureID"></param>
        public async Task<bool> DeleteLecture(int lectureID)
        {
            var response = await HttpClient.DeleteAsync(GetLectureUrl()+"/DeleteLecture/"+lectureID);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}

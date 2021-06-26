using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SEIIApp.Shared;

namespace SEIIApp.Client.Services
{
    public class UserBackendAccessService
    {
        private HttpClient HttpClient { get; set; }

        public UserBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        private string GetUserUrl()
        {
            return "api/users";
        }

        private string GetUserUrlWithId(int id)
        {
            return $"{GetUserUrl()}/{id}";
        }

        /// <summary>
        /// Returns all users stored on the backend.
        /// </summary>
        /// <returns></returns>
        public async Task<UserDTO[]> GetAllUsers()
        {
            return await HttpClient.GetFromJsonAsync<UserDTO[]>(GetUserUrl());
        }

        /// <summary>
        /// Returns a certain user by id.
        /// </summary>
        public async Task<UserDTO> GetUserById(int id)
        {
            return await HttpClient.GetFromJsonAsync<UserDTO>(GetUserUrlWithId(id));

        }

        /// <summary>
        /// Returns a user if the login was successful.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public async Task<UserDTO> LoginUser(string name, string pw)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<UserDTO>(GetUserUrl() + $"/login?name={name}&pw={pw}");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a user if the registration was successful.
        /// </summary>
        /// <param name="li"></param>
        /// <returns></returns>
        public async Task<UserDTO> RegisterUser(LoginInformationDTO li)
        {
            var response = await HttpClient.PutAsJsonAsync(GetUserUrl() + "/register", li);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<UserDTO>();
            }
            else return null;
        }

        /// <summary>
        /// Updates a user on the backend. Returns the user if successful else null.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public async Task<UserDTO> ChangeUser(UserDTO userDTO)
        {
            var response = await HttpClient.PutAsJsonAsync(GetUserUrl() + "/change", userDTO);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<UserDTO>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a user and returns true if successful.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(int id)
        {
            var response = await HttpClient.DeleteAsync(GetUserUrlWithId(id));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}

   

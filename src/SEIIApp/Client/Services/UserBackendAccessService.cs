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

        public async Task<UserDTO> LoginUser(string name, string pw)
        {
            return await HttpClient.GetFromJsonAsync<UserDTO>(GetUserUrl() + $"/login?name={name}&pw={pw}");
        }

        public async Task<UserDTO[]> GetAllUsers()
        {
            return await HttpClient.GetFromJsonAsync<UserDTO[]>(GetUserUrl());
        }

        public async Task<UserDTO> RegisterUser(LoginInformationDTO li)
        {
            var response = await HttpClient.PutAsJsonAsync(GetUserUrl() + "/register", li);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<UserDTO>();
            }
            else return null;
        }
        
        public async Task<UserDTO> ChangeUser(UserDTO userDTO)
        {
            var response = await HttpClient.PutAsJsonAsync(GetUserUrl() + "/change", userDTO);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<UserDTO>();
            }
            else return null;
        }
         
        public async Task<bool> DeleteUser(int id)
        {
            var response = await HttpClient.DeleteAsync(GetUserUrl() + $"/{id}");
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}

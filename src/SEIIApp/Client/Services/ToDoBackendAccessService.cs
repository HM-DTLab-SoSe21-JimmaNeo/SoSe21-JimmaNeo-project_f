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

    public class ToDoBackendAccessService
    {

        private HttpClient HttpClient { get; set; }

        public ToDoBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        private string GetToDoUrl()
        {
            return "api/todos";
        }

        private string GetToDoUrlWithId(int todoID)
        {
            return $"{GetToDoUrl()}/{todoID}";
        }

        private string GetToDoUrlWithAuthor(int authorID)
        {
            return $"{GetToDoUrl()}/author/{authorID}";
        }

        /// <summary>
        /// Returns a certain todo by id
        /// </summary>
        /// <param name="todoID"></param>
        /// <returns></returns>
        public async Task<ToDoDTO> GetToDoById(int todoID)
        {
            return await HttpClient.GetFromJsonAsync<ToDoDTO>(GetToDoUrlWithId(todoID));
        }

        /// <summary>
        /// Returns all todos created by an author with authorId
        /// </summary> 
        /// <param name="authorID"></param>
        /// <returns></returns>
        public async Task<List<ToDoDTO>> GetToDosByAuthor(int authorID)
        {
            return await HttpClient.GetFromJsonAsync<List<ToDoDTO>>(GetToDoUrlWithAuthor(authorID));
        }


        /// <summary>
        /// Returns all todos stored on the backend
        /// </summary>
        public async Task<List<ToDoDTO>> GetToDoOverview()
        {
            return await HttpClient.GetFromJsonAsync<List<ToDoDTO>>(GetToDoUrl());
        }

        /// <summary>
        /// Adds or updates a todo on the backend. Returns the tests if successful else null
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ToDoDTO> AddOrUpdateToDo(ToDoDTO dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetToDoUrl(), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<ToDoDTO>();
            }
            return null;
        }

        /// <summary>
        /// Deletes a todo and returns true if successful
        /// </summary>
        /// <param name="ToDoID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteToDo(int ToDoID)
        {
            var response = await HttpClient.DeleteAsync(GetToDoUrlWithId(ToDoID));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }



    }
}

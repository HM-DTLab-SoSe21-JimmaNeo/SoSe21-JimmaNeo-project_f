using System;
using System.Collections.Generic;
using System.Linq;
using SEIIApp.Server.Domain;
using System.Threading.Tasks;
using SEIIApp.Server.DataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SEIIApp.Server.Services
{
    public class ToDoService
    {
        private DatabaseContext DatabaseContext { get; set; }
        private UserService UserService { get; set; }
        private IMapper Mapper { get; set; }

        public ToDoService(DatabaseContext db, IMapper mapper, UserService userService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.UserService = userService;
        }

        private IQueryable<ToDo> GetQueryableForToDo()
        {
            return DatabaseContext.ToDo
                    .Include(todo => todo.Author);
        }

        /// <summary>
        /// Returns an array with all todos.
        /// </summary>
        /// <returns></returns>
        public ToDo[] GetAllToDo()
        {
            return GetQueryableForToDo().ToArray();
        }

        /// <summary>
        /// Returns a todo with specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDo GetToDoWithId(int id)
        {
            return GetQueryableForToDo().Where(ToDo => ToDo.ToDoID == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns a todo with specific task.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public ToDo GetToDoWithTask(string task)
        {
            return GetQueryableForToDo().Where(ToDo => ToDo.Task.Equals(task)).FirstOrDefault();
        }

        /// <summary>
        /// Returns a todo created by author with specific userID.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ToDo> GetToDoWithAuthorID(int userID)
        {
            return GetQueryableForToDo().Where(ToDo => ToDo.Author.UserId == userID).ToList();
        }

        /// <summary>
        /// Adds given todo to database.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public ToDo AddToDo(ToDo todo)
        {
            User user = UserService.GetUserWithId(todo.Author.UserId);

            if (user == null) return null;

            todo.Author = user;

            DatabaseContext.ToDo.Add(todo);
            DatabaseContext.SaveChanges();
            return todo;
        }

        /// <summary>
        /// Updates given todo in database.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public ToDo UpdateToDo(ToDo todo)
        {
            var existingToDo = GetToDoWithId(todo.ToDoID);

            existingToDo = Mapper.Map(todo, existingToDo); 

            DatabaseContext.ToDo.Update(existingToDo);
            DatabaseContext.SaveChanges();
            return existingToDo;
        }

        /// <summary>
        /// Deletes given todo from database.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public void RemoveToDo(ToDo todo)
        {
            DatabaseContext.ToDo.Remove(todo);
            DatabaseContext.SaveChanges();
        }
    }
}

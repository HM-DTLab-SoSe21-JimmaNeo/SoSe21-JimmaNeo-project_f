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

        public ToDo[] GetAllToDo()
        {
            return GetQueryableForToDo().ToArray();
        }

        public ToDo GetToDoWithId(int id)
        {
            return GetQueryableForToDo().Where(ToDo => ToDo.ToDoID == id).FirstOrDefault();
        }

        public ToDo GetToDoWithTask(string task)
        {
            return GetQueryableForToDo().Where(ToDo => ToDo.Task.Equals(task)).FirstOrDefault();
        }

        public List<ToDo> GetToDoWithAuthorID(int userID)
        {
            return GetQueryableForToDo().Where(ToDo => ToDo.Author.UserId == userID).ToList();
        }

        public ToDo AddToDo(ToDo todo)
        {
            User user = UserService.GetUserWithId(todo.Author.UserId);

            if (user == null) return null;

            todo.Author = user;

            DatabaseContext.ToDo.Add(todo);
            DatabaseContext.SaveChanges();
            return todo;
        }

        public ToDo UpdateToDo(ToDo todo)
        {
            var existingToDo = GetToDoWithId(todo.ToDoID);

            existingToDo = Mapper.Map(todo, existingToDo); // keine Auswirkung

            DatabaseContext.ToDo.Update(existingToDo);
            DatabaseContext.SaveChanges();
            return existingToDo;
        }

        public void RemoveToDo(ToDo todo)
        {
            DatabaseContext.ToDo.Remove(todo);
            DatabaseContext.SaveChanges();
        }
    }
}

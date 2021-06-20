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

        private IMapper Mapper { get; set; }

        public ToDoService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<ToDo> GetQueryableForToDo()
        {
            return DatabaseContext.ToDo;
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

        public ToDo GetToDoWithAuthorID(int userID)
        {
            return GetQueryableForToDo().Where(ToDo => ToDo.Author.UserId == userID).FirstOrDefault();
        }

        public ToDo AddToDo(ToDo todo)
        {
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

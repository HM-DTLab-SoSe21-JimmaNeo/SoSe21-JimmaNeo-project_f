using System;
using System.Collections.Generic;
using System.Linq;
using SEIIApp.Server.Domain;
using System.Threading.Tasks;
using SEIIApp.Server.DataAccess;
using AutoMapper;

namespace SEIIApp.Server.Services
{
    public class UserService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public UserService(DatabaseContext db, IMapper mapper) 
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<User> GetQueryableForUser()
        {
            return DatabaseContext.User;
        }

        public User[] GetAllUser()
        {
            return GetQueryableForUser().ToArray();
        }

        public User GetUserWithId(int id)
        {
            return GetQueryableForUser().Where(user => user.UserId == id).FirstOrDefault();
        }

        public User GetUserWithName(string name)
        {
            return GetQueryableForUser().Where(user => user.Name.Equals(name)).FirstOrDefault();
        }

        public User AddUser(User user)
        {
            DatabaseContext.User.Add(user);
            DatabaseContext.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            var existingUser = GetUserWithId(user.UserId);
           
            Mapper.Map(user, existingUser); // keine Auswirkung

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Role = user.Role;

            DatabaseContext.User.Update(existingUser);
            DatabaseContext.SaveChanges();
            return existingUser;
        }

        public void RemoveUser(User user)
        {
            DatabaseContext.User.Remove(user);
            DatabaseContext.SaveChanges();
        }
    }
}

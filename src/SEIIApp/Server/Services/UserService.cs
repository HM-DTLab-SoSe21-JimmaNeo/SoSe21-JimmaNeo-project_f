using AutoMapper;
using SEIIApp.Server.Domain;
using SEIIApp.Server.DataAccess;
using System.Linq;

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

        /// <summary>
        /// Returns all users. 
        /// </summary>
        /// <returns></returns>
        public User[] GetAllUser()
        {
            return GetQueryableForUser().ToArray();
        }

        /// <summary>
        /// Returns a user with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserWithId(int id)
        {
            return GetQueryableForUser().Where(user => user.UserId == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns a user with given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserWithName(string name)
        {
            return GetQueryableForUser().Where(user => user.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Adds a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddUser(User user)
        {
            DatabaseContext.User.Add(user);
            DatabaseContext.SaveChanges();
            return user;
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Removes a user and all dependencies. 
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            DatabaseContext.User.Remove(user);
            DatabaseContext.SaveChanges();
        }
    }
}

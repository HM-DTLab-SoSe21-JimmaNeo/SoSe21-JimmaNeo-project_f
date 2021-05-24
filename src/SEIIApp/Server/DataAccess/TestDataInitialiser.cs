using System;
using System.Collections.Generic;
using Test.Server.Domain;
using Test.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.DataAccess
{
    public class TestDataInitialiser
    {
        public static void InitalizeTestData(Services.UserService userService)
        {

            for (int i = 0; i < 6; i++)
            {
                Role role;
                if (i < 2) role = Role.Admin;
                else if (i % 2 == 0) role = Role.Teacher;
                else role = Role.Student;

                User u = GenerateUser(i, role);
                userService.AddUser(u);
            }
        }

        private static User GenerateUser(int id, Role role)
        {
            User u = new User();
            u.Name = $"user{id}";
            u.Pw = $"pw{id}";
            u.Role = role;
            return u;
        }
    }
}

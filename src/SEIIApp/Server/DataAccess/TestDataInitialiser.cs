using System;
using System.Collections.Generic;
using SEIIApp.Server.Domain;
using SEIIApp.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess
{
    public class TestDataInitialiser
    {
        public static void InitalizeTestData(Services.UserService userService, Services.TestService testService)
        {
            AddUser(userService);
            AddTests(testService, userService);          
        }

        private static void AddUser(Services.UserService userService)
        {
            for (int i = 1; i < 7; i++)
            {
                Role role;
                if (i < 3) role = Role.Admin;
                else if (i % 2 == 0) role = Role.Teacher;
                else role = Role.Student;

                User u = GenerateUser(i, role);
                userService.AddUser(u);
            }
        }

        private static void AddTests(Services.TestService testService, Services.UserService userService)
        {
            for (int i = 1; i < 10; i++)
            {
                var test = GenerateTest(userService);
                test.Topic = "Test " + i;
                test.Description = "ExampleTest " + i;
                testService.AddTest(test);
            }
        }

        public static Test GenerateTest(Services.UserService userService)
        {
            var test = new Test();
            test.Questions = new List<Question>();

            test.CreatedBy = userService.GetUserWithId(3);
            test.DateOfCreation = DateTime.Now;
            
            for (int i = 0; i < 3; i++)
            {
                var question = new Question();
                question.QuestionText = $"Question {i}";
                question.Answers = new List<Answer>();

                for (int c = 0; c < 5; c++)
                {
                    var answer = new Answer();
                    answer.AnswerText = $"Answer for Question {i} is {c}";
                    
                    if (c % 2 == 0) answer.IsCorrect = true;
                    else answer.IsCorrect = false;
                                     
                    
                    question.Answers.Add(answer);
                }
                test.Questions.Add(question);
            }

            return test;
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

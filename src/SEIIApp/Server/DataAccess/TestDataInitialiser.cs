﻿using System;
using System.Collections.Generic;
using SEIIApp.Server.Domain;
using SEIIApp.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess
{
    public class TestDataInitialiser
    {
        public static void InitalizeTestData(Services.UserService userService, Services.TestService testService, Services.NewsService newsService, Services.CompletedTestService completedTestService,Services.LectureService lectureService)
        {
            AddUser(userService);
            
            AddTests(testService, userService, newsService);
            AddCompletedTest(testService, userService, completedTestService); 
            AddLectures(lectureService, userService, testService);
        }

        private static void AddUser(Services.UserService userService)
        {
            User system = new User { Name = "system", FirstName = "", LastName = "", Role = Role.None, Pw = "system".GetHashCode().ToString() };
            userService.AddUser(system);

            for (int i = 2; i < 8; i++)
            {
                Role role;
                if (i < 4) role = Role.Admin;
                else if (i % 2 == 0) role = Role.Teacher;
                else role = Role.Student;

                User u = GenerateUser(i, role);
                userService.AddUser(u);
            }
        }

        private static void AddTests(Services.TestService testService, Services.UserService userService, Services.NewsService newsService)
        {
            for (int i = 1; i < 6; i++)
            {
                var test = GenerateTest(userService);
                test.Topic = "Test " + i;
                test.Description = "ExampleTest " + i;
                testService.AddTest(test);
            }
        }


     
        private static void AddCompletedTest(Services.TestService testService, Services.UserService userService, Services.CompletedTestService completedTestService)
        {
            Random random = new Random();
            User user = userService.GetUserWithId(7);
            for (int i = 1; i < 6; i++)
            {
                Test solved = testService.GetTestWithId(i);
                CompletedTest completedTest = new() { Student = user, SolvedTest = solved, ReachedPoints = random.Next( 0, 10)};

                completedTestService.AddCompletedTest(completedTest);
            }
        }


        private static User GenerateUser(int id, Role role)
        {
            User u = new User() { Name = $"user{id}", FirstName = $"first_{id}", LastName = $"last_{id}"};
            u.Pw = $"pw{id}".GetHashCode().ToString();
            u.Role = role;
            return u;
        }

        public static Test GenerateTest(Services.UserService userService)
        {
            var test = new Test();
            test.Questions = new List<Question>();

            test.Author = userService.GetUserWithId(4);
            test.DateOfCreation = DateTime.UtcNow.Date;
            
            for (int i = 0; i < 3; i++)
            {
                var question = new Question();
                question.QuestionText= $"Question {i}";
                question.Answers = new List<Answer>();
                question.Explanation = $"Die Antwort für Frage {i} ist ...";

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

        private static void AddLectures(Services.LectureService lectureService, Services.UserService userService, Services.TestService testservice)
        {
            for (int i = 1; i < 10; i++)
            {
                var lecture = GenerateLecture(userService);
                lecture.Topic = "Lecture " + i;
                lecture.LectureId = i;
                lecture.Videos = new List<VideoContent>();
                lecture.Content = new List<PictureContent>();
               // lecture.Videos.Add(new VideoContent() {VideoId =i, Description= "IpMan!!!", Path= "https://www.youtube.com/watch?v=Pi02ecWGXeo", VideoLink = "https://www.youtube.com/watch?v=Pi02ecWGXeo" });//;{VideoId = i  }
                if (lecture == null) Console.WriteLine("lecture ist null");
                lectureService.AddLecture(lecture);
               
               // test = new Services.TestService();
                lecture.Test = testservice.GetTestWithId(i);
                //lectureService.UpdateLecture(lecture);
            }
        }

        public static Lecture GenerateLecture(Services.UserService userService)
        {
           
            var lecture = new Lecture();
            lecture.DateOfCreation = DateTime.UtcNow.Date;
            
            lecture.Author = userService.GetUserWithId(4);
            lecture.Text = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam" +
                " erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea " +
                "rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolo" +
                "r sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam" +
                " nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed" +
                " diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. " +
                "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";


            /* for (int i = 0; i < 3; i++)
             {
                 var video = new VideoContent();
                 lecture.Text = $"Text {i} for lecture ";
                 video.Description = $"Description {i}";
                 //video.Path = $"https://www.youtube.com/embed/";


                 lecture.Videos.Add(video);
             }
             */
            return lecture;
        }

    }
}

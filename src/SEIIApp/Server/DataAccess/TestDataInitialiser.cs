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
        public static void InitalizeTestData(Services.UserService userService, Services.TestService testService, Services.NewsService newsService, Services.CompletedTestService completedTestService, Services.LectureService lectureService, Services.ToDoService toDoService)
        {
            AddUser(userService);

            AddTests(testService, userService, newsService);
            AddCompletedTest(testService, userService, completedTestService);
            AddLectures(lectureService, userService, testService);

            AddToDos(toDoService, userService);
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

            testService.AddTest(GenerateFirstTest(userService));
            for (int i = 2; i < 6; i++)
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
                CompletedTest completedTest = new() { Student = user, SolvedTest = solved, ReachedPoints = random.Next( 0, 10), MaxPoints = 9};


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

        public static Test GenerateFirstTest(Services.UserService userService)
        {
            var test1 = new Test();
            test1.Questions = new List<Question>();
            test1.Author = userService.GetUserWithId(4);
            test1.DateOfCreation = DateTime.UtcNow.Date;

            var question1 = new Question();

            question1.QuestionText = "1. Welche Aussage zur Erstversorge Neugeborener treffen zu? (Es können mehrere Antworten richtig sein)";
            question1.Answers = new List<Answer>();
            question1.Explanation = "Die Antwort für Frage 1 ist richtig, da es bei den meisten Geburten keine Probleme gibt. " +
            "Aufgabe 4 ist Außerdem richtig, da bei 10% der Neugeborenen nicht selbstständig atmen und deshalb intubiert werden müssen.";

            var answer1 = new Answer() { AnswerText = "Der Großteil aller Neugeborenen bedarf nach der Geburt keiner besonderen medizinischen Unterstützung.", IsCorrect = true };
            var answer2 = new Answer() { AnswerText = "Der Wärmeerhalt (36,5 -37,5 °C) nach Geburt ist für alle gesunden Neugeborenen von großer Wichtigkeit.", IsCorrect = false };
            var answer3 = new Answer() { AnswerText = "Nur ca. 30% aller Neugeborenen müssen nach Geburt beatmet werden.", IsCorrect = false };
            var answer4 = new Answer() { AnswerText = "ca. 10% aller Neugeborenen müssen nach Geburt intubiert werden.", IsCorrect = true };
            var answer5 = new Answer() { AnswerText = "Die medikamentöse Therapie spielt eine größere Rolle als die Herz-Druck-Massage.", IsCorrect = false };

            question1.Answers.Add(answer1);
            question1.Answers.Add(answer2);
            question1.Answers.Add(answer3);
            question1.Answers.Add(answer4);
            question1.Answers.Add(answer5);
            test1.Questions.Add(question1);




            var question2 = new Question();


            question2.QuestionText = "2. Folgende Faktoren können sich negativ auf die Anpassung des Neugeborenen auswirken? (Es können mehrere Antworten richtig sein.)";
            question2.Answers = new List<Answer>();
            question2.Explanation = "Die Antwort für Frage 3 ist richtig, da es bei Mehrlingsgeburten sehr häufig zu komplikationen kommt. " +
            "Antwort 4 ist Außerdem richtig, da Frühlinge vor der 34. Woche meistens noch nicht vollständig entwickelt sind. Antwort 5 ist richtig, da Blutungen vor der Geburt auch innere Verletzungen hinweisen können.";

            var answer12 = new Answer() { AnswerText = "Gestationsdiabetes (Schwangerschaftsdiabetes) der Mutter", IsCorrect = false };
            var answer22 = new Answer() { AnswerText = "Abgang von dick grünem Fruchtwasser", IsCorrect = false };
            var answer32 = new Answer() { AnswerText = "Mehrlingsgeburt", IsCorrect = true };
            var answer42 = new Answer() { AnswerText = "Frühgeburtlichkeit unter der 34. Schwangerschaftswoche", IsCorrect = true };
            var answer52 = new Answer() { AnswerText = "akute vaginale Blutung vor der Geburt", IsCorrect = true };

            question2.Answers.Add(answer12);
            question2.Answers.Add(answer22);
            question2.Answers.Add(answer32);
            question2.Answers.Add(answer42);
            question2.Answers.Add(answer52);
            test1.Questions.Add(question2);



            test1.Topic = "Erstversorgung";
            test1.Description = " Test für das Wissen bei der Erstversorgung";



            return test1;
        }

        private static void AddNews(Services.NewsService newsService)
        {
            News news = new() { Topic = "Este News", Content = "Dies ist die erste News auf diesem System", DateOfCreation = DateTime.UtcNow.Date };
            newsService.AddNews(news);
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
        private static void AddToDos(Services.ToDoService todoService, Services.UserService userService)
        {
            Random random = new Random();
            User user = userService.GetUserWithId(7);
            for (int i = 1; i < 6; i++)
            {
                ToDo todo = new() { ToDoID = i, Author = user, Task = "Important Task"+ i, IsDone = false };


                todoService.AddToDo(todo);
            }
        }


    }
}

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
        public static void InitalizeTestData(Services.UserService userService, Services.TestService testService, Services.CompletedTestService completedTestService, Services.LectureService lectureService, Services.ToDoService toDoService)
        {
            AddUser(userService);

            AddTests(testService, userService);
            AddCompletedTest(testService, userService, completedTestService);
            AddLectures(lectureService, userService, testService);

            AddToDos(toDoService, userService);
        }

        private static void AddUser(Services.UserService userService)
        {
            User admin = new() { Name = "admin", FirstName = "Example", LastName = "Admin", Role = Role.Admin, Pw = "admin".GetHashCode().ToString() };
            userService.AddUser(admin);

            User trainer = new() { Name = "trainer", FirstName = "Example", LastName = "Trainer", Role = Role.Trainer, Pw = "trainer".GetHashCode().ToString() };
            userService.AddUser(trainer);

            User student = new() { Name = "student", FirstName = "Example", LastName = "Student", Role = Role.Student, Pw = "student".GetHashCode().ToString() };
            userService.AddUser(student);

        }

        private static void AddTests(Services.TestService testService, Services.UserService userService)
        {
            testService.AddTest(GenerateFirstTest(userService));



            for (int i = 2; i < 4; i++)
            {
                var test = GenerateTest(userService);
                test.Topic = "Example Test " + i;
                test.Description = "This Test is just an example " + i;
                testService.AddTest(test);
            }
        }


     
        private static void AddCompletedTest(Services.TestService testService, Services.UserService userService, Services.CompletedTestService completedTestService)
        {
            Random random = new Random();
            User user = userService.GetUserWithId(3);
            
            Test solved = testService.GetTestWithId(3);
            CompletedTest completedTest = new() { Student = user, SolvedTest = solved, ReachedPoints = random.Next(3, 10), MaxPoints = 9};
            completedTestService.AddCompletedTest(completedTest);

            solved = testService.GetTestWithId(2);
            completedTest = new() { Student = user, SolvedTest = solved, ReachedPoints = random.Next(3, 10), MaxPoints = 9 };
            completedTestService.AddCompletedTest(completedTest);

            solved = testService.GetTestWithId(1);
            completedTest = new() { Student = user, SolvedTest = solved, ReachedPoints = random.Next(1, 5), MaxPoints = 5 };
            completedTestService.AddCompletedTest(completedTest);
        }


      
      public static Test GenerateTest(Services.UserService userService)
            {
                var test = new Test();
                test.Questions = new List<Question>();

                test.Author = userService.GetUserWithId(2);
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
            test1.Author = userService.GetUserWithId(2);
            test1.DateOfCreation = DateTime.UtcNow.Date;
            test1.Videos = new();

            test1.Videos.Add(new VideoContent() { Path = "ZlIknKErzV0", Description = "Infants  (under a year old) can choke and stop breathing if they swallow something larger than their tiny straw size air passage; THERE IS A WAY TO SAVE YOUR BABY from total abstraction! Learn the simple and proven way to make your baby breath until help comes to rescue. First hold the baby over your arm horizontal to the floor, next use your heal of your hand to give them 5 good solid back blows right between the shoulders, and then 5 compressions on the front of the chest with two fingers. You can do this sitting down. Check for the object to come out (the one that the infant swallowed). For a larger baby (1 year old or over) you can do the Heimlich maneuver by holding the baby from behind and doing the abdominal thrusts with less force than adults; get behind the baby at their level and thrust under their stomach" });

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

             


        

      
        private static void AddLectures(Services.LectureService lectureService, Services.UserService userService, Services.TestService testservice)
        {
            for (int i = 1; i < 6; i++)
            {
                var lecture = GenerateLecture(userService);
                lecture.Topic = "Lecture " + i;
                lecture.LectureId = i;
                lecture.Videos = new List<VideoContent>();
                lecture.Content = new List<PictureContent>();
                
                if (lecture == null) Console.WriteLine("lecture ist null");
                lectureService.AddLecture(lecture);
               
               
                lecture.Test = testservice.GetTestWithId(i);
               
            }
        }

        public static Lecture GenerateLecture(Services.UserService userService)
        {
           
            var lecture = new Lecture();
            lecture.DateOfCreation = DateTime.UtcNow.Date;
            
            lecture.Author = userService.GetUserWithId(2);
            lecture.Text = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam" +
                " erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea " +
                "rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolo" +
                "r sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam" +
                " nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed" +
                " diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. " +
                "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

            return lecture;
        }
        private static void AddToDos(Services.ToDoService todoService, Services.UserService userService)
        {
            Random random = new Random();
            User user = userService.GetUserWithId(3);
            for (int i = 1; i < 6; i++)
            {
                ToDo todo = new() { ToDoID = i, Author = user, Task = "Important Task"+ i, IsDone = false };


                todoService.AddToDo(todo);
            }
        }


    }
}

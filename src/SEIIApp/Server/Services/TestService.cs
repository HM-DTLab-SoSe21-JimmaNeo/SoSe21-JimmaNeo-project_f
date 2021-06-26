using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System;
using System.Linq;

namespace SEIIApp.Server.Services
{
    public class TestService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        private UserService UserService { get; set; }

        private NewsService NewsService { get; set; }

        public TestService(DatabaseContext db, IMapper mapper, UserService userService, NewsService newsService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.UserService = userService;
            this.NewsService = newsService;
        }

        private IQueryable<Test> GetQueryableForTest()
        {
            return DatabaseContext.Tests
                .Include(test => test.Questions).ThenInclude(questions => questions.Answers)
                .Include(test => test.Questions).ThenInclude(questions => questions.Pictures)
                .Include(test => test.Content)
                .Include(test => test.Videos)
                .Include(test => test.VideosFurtherInformation)
                .Include(test => test.FurtherLinks)
                .Include(test => test.Author);
        }

        /// <summary>
        /// Returns all tests. Includes also questions and their answers and pictures, 
        /// as well as content, videos, further informations + further links and the author.
        /// </summary>
        /// <returns></returns>
        public Test[] GetAllTests()
        {
            return GetQueryableForTest().ToArray();
        }

        /// <summary>
        /// Returns a test with given id. Includes also questions and their answers and pictures, 
        /// as well as content, videos, further informations + further links and the author.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Test GetTestWithId(int id)
        {
            return GetQueryableForTest().Where(test => test.TestId == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns a test with given topic. Includes also questions and their answers and pictures, 
        /// as well as content, videos, further informations + further links and the author. 
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public Test GetTestWithTopic(string topic)
        {
            return GetQueryableForTest().Where(test => test.Topic == topic).FirstOrDefault();
        }

        /// <summary>
        /// Adds a test.
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public Test AddTest(Test test)
        {
            User user = UserService.GetUserWithId(test.Author.UserId);

            if (user == null) return null;

            test.Author = user;

            DatabaseContext.Tests.Add(test);
            DatabaseContext.SaveChanges();

            NewsService.AddNews(new News()
            {
                Topic = "New Test",
                Content = $"A new Test, named {test.Topic}, was uploaded to this platform. The Test was created by {test.Author.Name}.",
                DateOfCreation = DateTime.Now,
                Creator = "System",
                Tags = "New ,Exam, Challenge, Power, FUN"
            });

            return test;
        }

        /// <summary>
        /// Updates a test. 
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public Test UpdateTest(Test test)
        {
            var exsistingTest = GetTestWithId(test.TestId);
            Mapper.Map(test, exsistingTest);

            DatabaseContext.Tests.Update(exsistingTest);
            DatabaseContext.SaveChanges();

            NewsService.AddNews(new News()
            {
                Topic = $"Updated Test {test.Topic}",
                Content = $"The Test \"{test.Topic}\" has been updated. The Test was updated by {test.Author.Name}.",
                DateOfCreation = DateTime.Now,
                Creator = "System",
                Tags = "New ,Exam, Challenge, Power, FUN"
            });

            return exsistingTest;
        }

        /// <summary>
        /// Removes a test and all dependencies. 
        /// </summary>
        /// <param name="test"></param>
        public void RemoveTest(Test test)
        {
            DatabaseContext.Tests.Remove(test);
            DatabaseContext.SaveChanges();
        }

    }
}

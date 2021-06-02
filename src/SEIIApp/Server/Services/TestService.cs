using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Services
{
    public class TestService
    {
        private DatabaseContext DatabaseContext {get; set; }

        private IMapper Mapper { get; set; }

        private UserService UserService { get; set; }

        public TestService(DatabaseContext db, IMapper mapper, UserService userService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.UserService = userService;
        }

        private IQueryable<Test> GetQueryableForTest()
        {
            return DatabaseContext.Tests
                .Include(test => test.Questions).ThenInclude(questions => questions.Answers)
                .Include(test => test.TestContent)
                .Include(test => test.Videos)
                .Include(test => test.FurtherLinks)
                .Include(test => test.Author);
        }

        public Test[] GetAllTests()
        {
            return GetQueryableForTest().ToArray();
        }

        public Test GetTestWithId(int id)
        {
            return GetQueryableForTest().Where(test => test.TestId == id).FirstOrDefault();
        }

        public Test AddTest(Test test)
        {
            User user = UserService.GetUserWithId(test.Author.UserId);

            if (user == null) return null;

            test.Author = user;

            DatabaseContext.Tests.Add(test);
            DatabaseContext.SaveChanges();
            return test;
        }

        public Test UpdateTest(Test test)
        {          
            var exsistingTest = GetTestWithId(test.TestId);
            test.Author = exsistingTest.Author;
            Mapper.Map(test, exsistingTest); // TODO Diese Zeile hat keine Auswirkung 

            exsistingTest.Topic = test.Topic;
            exsistingTest.Description = test.Description;
            exsistingTest.Questions = test.Questions;
            exsistingTest.Videos = test.Videos;
            exsistingTest.FurtherLinks = test.FurtherLinks;
            exsistingTest.TestContent = test.TestContent;

            DatabaseContext.Tests.Update(exsistingTest);
            DatabaseContext.SaveChanges();
            return exsistingTest;
        } 

        public void RemoveTest(Test test)
        {
            DatabaseContext.Tests.Remove(test);
            DatabaseContext.SaveChanges();
        }

    }
}

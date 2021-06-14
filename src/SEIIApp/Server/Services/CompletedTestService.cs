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
    public class CompletedTestService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        UserService UserService { get; set; }

        TestService TestService { get; set; }

        public CompletedTestService(DatabaseContext db, IMapper mapper, UserService userService, TestService testService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.UserService = userService;
            this.TestService = testService;
        }

        private IQueryable<CompletedTest> GetQueryableForTest()
        {
            return DatabaseContext.CompletedTests
                .Include(completedTest => completedTest.SolvedTest)
                .Include(completeTest => completeTest.Student);
        }

        public CompletedTest GetCompletedTestWithId(int id)
        {
            return GetQueryableForTest().Where(completedTest => completedTest.CtId == id).FirstOrDefault();
        }

        public CompletedTest[] GetCompletedTestsWithUserId(int userId)
        {
            return GetQueryableForTest().Where(completedTest => completedTest.Student.UserId == userId).ToArray();
        }

        public CompletedTest[] GetCompletedTestsWithTestId(int testId)
        {
            return GetQueryableForTest().Where(completedTest => completedTest.SolvedTest.TestId == testId).ToArray();
        }

        public CompletedTest AddCompletedTest(CompletedTest completedTest)
        {
            if (completedTest.SolvedTest == null || completedTest.Student == null) return null;
            
            User user = UserService.GetUserWithId(completedTest.Student.UserId);
            Test test = TestService.GetTestWithId(completedTest.SolvedTest.TestId);

            if (user == null || test == null) return null;

            completedTest.Student = user;
            completedTest.SolvedTest = test;

            DatabaseContext.CompletedTests.Add(completedTest);
            DatabaseContext.SaveChanges();
            return completedTest;
        }


    }
}

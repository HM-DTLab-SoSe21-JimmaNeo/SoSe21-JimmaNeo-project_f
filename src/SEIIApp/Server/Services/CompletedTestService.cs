using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services
{
    public class CompletedTestService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        private UserService UserService { get; set; }

        private TestService TestService { get; set; }

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

        /// <summary>
        /// Returns a completed test with given id. Includes the solved test and student who solved the test.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompletedTest GetCompletedTestWithId(int id)
        {
            return GetQueryableForTest().Where(completedTest => completedTest.CtId == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns all completed tests for a user by his user-id. Includes the solved test and student who solved the test.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CompletedTest[] GetCompletedTestsWithUserId(int userId)
        {
            return GetQueryableForTest().Where(completedTest => completedTest.Student.UserId == userId).ToArray();
        }

        /// <summary>
        /// Returns all completed tests for a concrete test by it´s test-id. Includes the solved test and student who solved the test.
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
        public CompletedTest[] GetCompletedTestsWithTestId(int testId)
        {
            return GetQueryableForTest().Where(completedTest => completedTest.SolvedTest.TestId == testId).ToArray();
        }

        /// <summary>
        /// Returns all completed tests which were created by the author with the given id. Includes the solved test and student who solved the test.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public CompletedTest[] GetCompletedTestsWithAuthorId(int authorId)
        {
            return GetQueryableForTest().Where(completedTest => completedTest.SolvedTest.Author.UserId == authorId).ToArray();
        }

        /// <summary>
        /// Adds a completed test.
        /// </summary>
        /// <param name="completedTest"></param>
        /// <returns></returns>
        public CompletedTest AddCompletedTest(CompletedTest completedTest)
        {
            
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
